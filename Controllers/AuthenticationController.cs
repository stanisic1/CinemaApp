using CinemaApp.Models.DTO;
using CinemaApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace CinemaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
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
        [Route("register")]
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
        [Route("update-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateRoleDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid role update parameters.");
            }

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            var removeRolesResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);

            if (!removeRolesResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error removing user roles.");
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, model.Role);
            if (!addRoleResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding user role.");
            }

            return Ok(new { message = "User role updated successfully!" });
        }

        [HttpGet]
        [Route("userinfo")]
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

        [HttpPost]
        [Route("change-password")]
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
        [Route("all-users")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            var userDTOs = new List<UserDTO>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();

                userDTOs.Add(new UserDTO
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Role = role
                });
            }

            return Ok(userDTOs);
        }


    }
}
