using CinemaApp.Models.DTO;
using CinemaApp.Models;
using CinemaApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CinemaApp.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly ITicketRepository _ticketRepository;
        private readonly IProjectionRepository _projectionRepository;

        public AuthenticationController(ILogger<AuthenticationController> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ITicketRepository ticketRepository, IProjectionRepository projectionRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _logger = logger;
            _ticketRepository = ticketRepository;
            _projectionRepository = projectionRepository;
        }

        [HttpPost]
        [Route("api/authentication/login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Login parameters invalid.");
            }

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddHours(2),      // token valid for 2 hours
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new TokenDTO()
                {
                    Username = user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    Role = userRoles.FirstOrDefault()
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("api/authentication/register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Registration parameters invalid.");
            }

            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return BadRequest("User already exists");
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest($"User creation failed: {string.Join(", ", errors)}");
            }

            var userRole = string.IsNullOrEmpty(model.Role) ? "User" : model.Role;

            
            switch (userRole.ToLower())
            {
                case "administrator":
                    userRole = "Admin";
                    break;
                case "regular user":
                default:
                    userRole = "User";
                    break;
            }

            if (!await _roleManager.RoleExistsAsync(userRole))
            {
                await _roleManager.CreateAsync(new IdentityRole(userRole));
            }

            await _userManager.AddToRoleAsync(user, userRole);
           

            return Ok(new { message = "User registered successfully!" });
        }

        [HttpPost]
        [Route("api/authentication/update-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateRoleDTO model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid role update parameters.");
                return BadRequest("Invalid role update parameters.");
            } 

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                _logger.LogWarning($"User not found: {model.Username}");
                return NotFound("User not found.");
            }

            var validRoles = new List<string> { "User", "Admin" };

            var receivedRole = model.Role.Trim();
            _logger.LogInformation($"Received Role: {receivedRole}");

            var normalizedRole = validRoles.FirstOrDefault(role => string.Equals(role, receivedRole, StringComparison.OrdinalIgnoreCase));
            _logger.LogInformation($"Normalized Role: {normalizedRole}");

            if (normalizedRole == null)
            {
                _logger.LogWarning($"Invalid role specified: {receivedRole}");
                return BadRequest("Invalid role specified.");
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            _logger.LogInformation($"Current Roles: {string.Join(", ", currentRoles)}");

            var removeRolesResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeRolesResult.Succeeded)
            {
                _logger.LogError($"Error removing user roles for {user.UserName}: {string.Join(", ", removeRolesResult.Errors.Select(e => e.Description))}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error removing user roles.");
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, normalizedRole);
            if (!addRoleResult.Succeeded)
            {
                _logger.LogError($"Error adding user role for {user.UserName}: {string.Join(", ", addRoleResult.Errors.Select(e => e.Description))}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding user role.");
            }

            _logger.LogInformation($"User role updated successfully for {user.UserName}");
            return Ok(new { message = "User role updated successfully!" });
        }


        [HttpGet]
        [Route("api/authentication/userinfo")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();

            var userInfo = new UserInfoDTO
            {
                Username = user.UserName,
                Email = user.Email,
                Role = role
            };

            return Ok(userInfo);
        }
        [HttpGet]
        [Route("api/authentication/userinfo/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserInfoByAdmin(string userId)
        {
            if (userId == null)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();

            var userInfo = new UserInfoDTO
            {
                Username = user.UserName,
                Email = user.Email,
                Role = role
            };

            return Ok(userInfo);
        }

        [HttpPost]
        [Route("api/authentication/change-password")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid password change parameters.");
            }

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest($"Password change failed: {string.Join(", ", errors)}");
            }

            return Ok(new { message = "Password changed successfully!" });
        }

        [HttpGet]
        [Route("api/authentication/all-users")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers(string? username, string? sortBy = null, string? sortDirection = null)
        {
            var usersQuery = string.IsNullOrEmpty(username)
                            ? _userManager.Users
                            : _userManager.Users.Where(u => u.UserName.Contains(username));

            var users = await usersQuery.ToListAsync();
            var userDTOs = new List<UserDTO>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();

                userDTOs.Add(new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Role = role
                });
            }

           
            if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(sortDirection))
            {
                switch (sortBy.ToLower())
                {
                    case "role":
                        userDTOs = sortDirection.ToLower() == "asc"
                            ? userDTOs.OrderBy(u => u.Role).ToList()
                            : userDTOs.OrderByDescending(u => u.Role).ToList();
                        break;
                    case "username":
                        userDTOs = sortDirection.ToLower() == "asc"
                            ? userDTOs.OrderBy(u => u.Username).ToList()
                            : userDTOs.OrderByDescending(u => u.Username).ToList();
                        break;
                    default:
                        break;
                }
            }

            return Ok(userDTOs);
        }

        [HttpDelete]
        [Route("api/authentication/delete-user/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (!isAdmin)
            {
                await _ticketRepository.DeleteTicketsByUserIdAsync(userId);
            }



            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting user.");
            }

            return Ok(new { message = "User deleted successfully!" });
        }

    }
}
