using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class CleanSlate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Actors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Distributor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theaters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theaters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TheaterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectionTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectionTypes_Theaters_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "Theaters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ProjectionTypeId = table.Column<int>(type: "int", nullable: false),
                    TheaterId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AdministratorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projections_AspNetUsers_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projections_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projections_ProjectionTypes_ProjectionTypeId",
                        column: x => x.ProjectionTypeId,
                        principalTable: "ProjectionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projections_Theaters_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "Theaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    ProjectionId = table.Column<int>(type: "int", nullable: false),
                    TheaterId = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Projections_ProjectionId",
                        column: x => x.ProjectionId,
                        principalTable: "Projections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seats_Theaters_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "Theaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectionId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    SaleDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Projections_ProjectionId",
                        column: x => x.ProjectionId,
                        principalTable: "Projections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "0693bd91-7741-4a9d-ab35-ff20c5a81985", "admin1@example.com", true, false, null, "ADMIN1@EXAMPLE.COM", "ADMIN1", "AQAAAAIAAYagAAAAECr9IvlgKvhYnCc0oFGjxb0TuTEhc+0SnDBR7VJ3mv8jiRB13LH6UoPwxYkuNhmdLQ==", null, false, "", false, "admin1" },
                    { "2", 0, "faf3580b-7ddb-4d42-be7a-b6bb98c69ca7", "admin2@example.com", true, false, null, "ADMIN2@EXAMPLE.COM", "ADMIN2", "AQAAAAIAAYagAAAAEGQf+2KBrR/+XzPgUQH6nlyTqfyQ7A8nGZxnN6aCcwAtaE/gATdMBoGVUCCjdycnsQ==", null, false, "", false, "admin2" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Actors", "CountryOrigin", "Description", "Director", "Distributor", "Duration", "Genre", "IsDeleted", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Bruce Willis, Uma Thurman", "USA", "Exciting crime drama", "Quentin Tarantino", "Miramax", 150, "Crime Story", false, 1994, "Pulp Fiction" },
                    { 2, "Keir Dullea, Gary Lockwood", "USA", "Experiment in film form and content", "Stanley Kubrick", "Warner Bros", 149, "Sci-fi/Adventure", false, 1968, "2001: A Space Odyssey" }
                });

            migrationBuilder.InsertData(
                table: "ProjectionTypes",
                columns: new[] { "Id", "TheaterId", "Type" },
                values: new object[,]
                {
                    { 1, null, 1 },
                    { 2, null, 2 },
                    { 3, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Theaters",
                columns: new[] { "Id", "Capacity", "Type" },
                values: new object[,]
                {
                    { 1, 100, 1 },
                    { 2, 150, 2 },
                    { 3, 200, 3 }
                });

            migrationBuilder.InsertData(
                table: "Projections",
                columns: new[] { "Id", "AdministratorId", "DateTime", "IsDeleted", "MovieId", "Price", "ProjectionTypeId", "TheaterId" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2024, 7, 23, 17, 35, 31, 804, DateTimeKind.Local).AddTicks(5343), false, 1, 500m, 2, 1 },
                    { 2, "2", new DateTime(2024, 7, 23, 17, 35, 31, 804, DateTimeKind.Local).AddTicks(5551), false, 2, 500m, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "IsAvailable", "Number", "ProjectionId", "TheaterId" },
                values: new object[,]
                {
                    { 1, true, 1, 1, 1 },
                    { 2, true, 2, 1, 1 },
                    { 3, true, 3, 1, 1 },
                    { 4, true, 4, 1, 1 },
                    { 5, true, 5, 1, 1 },
                    { 6, true, 6, 1, 1 },
                    { 7, true, 7, 1, 1 },
                    { 8, true, 8, 1, 1 },
                    { 9, true, 9, 1, 1 },
                    { 10, true, 10, 1, 1 },
                    { 11, true, 11, 1, 1 },
                    { 12, true, 12, 1, 1 },
                    { 13, true, 13, 1, 1 },
                    { 14, true, 14, 1, 1 },
                    { 15, true, 15, 1, 1 },
                    { 16, true, 16, 1, 1 },
                    { 17, true, 17, 1, 1 },
                    { 18, true, 18, 1, 1 },
                    { 19, true, 19, 1, 1 },
                    { 20, true, 20, 1, 1 },
                    { 21, true, 21, 1, 1 },
                    { 22, true, 22, 1, 1 },
                    { 23, true, 23, 1, 1 },
                    { 24, true, 24, 1, 1 },
                    { 25, true, 25, 1, 1 },
                    { 26, true, 26, 1, 1 },
                    { 27, true, 27, 1, 1 },
                    { 28, true, 28, 1, 1 },
                    { 29, true, 29, 1, 1 },
                    { 30, true, 30, 1, 1 },
                    { 31, true, 31, 1, 1 },
                    { 32, true, 32, 1, 1 },
                    { 33, true, 33, 1, 1 },
                    { 34, true, 34, 1, 1 },
                    { 35, true, 35, 1, 1 },
                    { 36, true, 36, 1, 1 },
                    { 37, true, 37, 1, 1 },
                    { 38, true, 38, 1, 1 },
                    { 39, true, 39, 1, 1 },
                    { 40, true, 40, 1, 1 },
                    { 41, true, 41, 1, 1 },
                    { 42, true, 42, 1, 1 },
                    { 43, true, 43, 1, 1 },
                    { 44, true, 44, 1, 1 },
                    { 45, true, 45, 1, 1 },
                    { 46, true, 46, 1, 1 },
                    { 47, true, 47, 1, 1 },
                    { 48, true, 48, 1, 1 },
                    { 49, true, 49, 1, 1 },
                    { 50, true, 50, 1, 1 },
                    { 51, true, 51, 1, 1 },
                    { 52, true, 52, 1, 1 },
                    { 53, true, 53, 1, 1 },
                    { 54, true, 54, 1, 1 },
                    { 55, true, 55, 1, 1 },
                    { 56, true, 56, 1, 1 },
                    { 57, true, 57, 1, 1 },
                    { 58, true, 58, 1, 1 },
                    { 59, true, 59, 1, 1 },
                    { 60, true, 60, 1, 1 },
                    { 61, true, 61, 1, 1 },
                    { 62, true, 62, 1, 1 },
                    { 63, true, 63, 1, 1 },
                    { 64, true, 64, 1, 1 },
                    { 65, true, 65, 1, 1 },
                    { 66, true, 66, 1, 1 },
                    { 67, true, 67, 1, 1 },
                    { 68, true, 68, 1, 1 },
                    { 69, true, 69, 1, 1 },
                    { 70, true, 70, 1, 1 },
                    { 71, true, 71, 1, 1 },
                    { 72, true, 72, 1, 1 },
                    { 73, true, 73, 1, 1 },
                    { 74, true, 74, 1, 1 },
                    { 75, true, 75, 1, 1 },
                    { 76, true, 76, 1, 1 },
                    { 77, true, 77, 1, 1 },
                    { 78, true, 78, 1, 1 },
                    { 79, true, 79, 1, 1 },
                    { 80, true, 80, 1, 1 },
                    { 81, true, 81, 1, 1 },
                    { 82, true, 82, 1, 1 },
                    { 83, true, 83, 1, 1 },
                    { 84, true, 84, 1, 1 },
                    { 85, true, 85, 1, 1 },
                    { 86, true, 86, 1, 1 },
                    { 87, true, 87, 1, 1 },
                    { 88, true, 88, 1, 1 },
                    { 89, true, 89, 1, 1 },
                    { 90, true, 90, 1, 1 },
                    { 91, true, 91, 1, 1 },
                    { 92, true, 92, 1, 1 },
                    { 93, true, 93, 1, 1 },
                    { 94, true, 94, 1, 1 },
                    { 95, true, 95, 1, 1 },
                    { 96, true, 96, 1, 1 },
                    { 97, true, 97, 1, 1 },
                    { 98, true, 98, 1, 1 },
                    { 99, true, 99, 1, 1 },
                    { 100, true, 100, 1, 1 },
                    { 101, true, 1, 2, 2 },
                    { 102, true, 2, 2, 2 },
                    { 103, true, 3, 2, 2 },
                    { 104, true, 4, 2, 2 },
                    { 105, true, 5, 2, 2 },
                    { 106, true, 6, 2, 2 },
                    { 107, true, 7, 2, 2 },
                    { 108, true, 8, 2, 2 },
                    { 109, true, 9, 2, 2 },
                    { 110, true, 10, 2, 2 },
                    { 111, true, 11, 2, 2 },
                    { 112, true, 12, 2, 2 },
                    { 113, true, 13, 2, 2 },
                    { 114, true, 14, 2, 2 },
                    { 115, true, 15, 2, 2 },
                    { 116, true, 16, 2, 2 },
                    { 117, true, 17, 2, 2 },
                    { 118, true, 18, 2, 2 },
                    { 119, true, 19, 2, 2 },
                    { 120, true, 20, 2, 2 },
                    { 121, true, 21, 2, 2 },
                    { 122, true, 22, 2, 2 },
                    { 123, true, 23, 2, 2 },
                    { 124, true, 24, 2, 2 },
                    { 125, true, 25, 2, 2 },
                    { 126, true, 26, 2, 2 },
                    { 127, true, 27, 2, 2 },
                    { 128, true, 28, 2, 2 },
                    { 129, true, 29, 2, 2 },
                    { 130, true, 30, 2, 2 },
                    { 131, true, 31, 2, 2 },
                    { 132, true, 32, 2, 2 },
                    { 133, true, 33, 2, 2 },
                    { 134, true, 34, 2, 2 },
                    { 135, true, 35, 2, 2 },
                    { 136, true, 36, 2, 2 },
                    { 137, true, 37, 2, 2 },
                    { 138, true, 38, 2, 2 },
                    { 139, true, 39, 2, 2 },
                    { 140, true, 40, 2, 2 },
                    { 141, true, 41, 2, 2 },
                    { 142, true, 42, 2, 2 },
                    { 143, true, 43, 2, 2 },
                    { 144, true, 44, 2, 2 },
                    { 145, true, 45, 2, 2 },
                    { 146, true, 46, 2, 2 },
                    { 147, true, 47, 2, 2 },
                    { 148, true, 48, 2, 2 },
                    { 149, true, 49, 2, 2 },
                    { 150, true, 50, 2, 2 },
                    { 151, true, 51, 2, 2 },
                    { 152, true, 52, 2, 2 },
                    { 153, true, 53, 2, 2 },
                    { 154, true, 54, 2, 2 },
                    { 155, true, 55, 2, 2 },
                    { 156, true, 56, 2, 2 },
                    { 157, true, 57, 2, 2 },
                    { 158, true, 58, 2, 2 },
                    { 159, true, 59, 2, 2 },
                    { 160, true, 60, 2, 2 },
                    { 161, true, 61, 2, 2 },
                    { 162, true, 62, 2, 2 },
                    { 163, true, 63, 2, 2 },
                    { 164, true, 64, 2, 2 },
                    { 165, true, 65, 2, 2 },
                    { 166, true, 66, 2, 2 },
                    { 167, true, 67, 2, 2 },
                    { 168, true, 68, 2, 2 },
                    { 169, true, 69, 2, 2 },
                    { 170, true, 70, 2, 2 },
                    { 171, true, 71, 2, 2 },
                    { 172, true, 72, 2, 2 },
                    { 173, true, 73, 2, 2 },
                    { 174, true, 74, 2, 2 },
                    { 175, true, 75, 2, 2 },
                    { 176, true, 76, 2, 2 },
                    { 177, true, 77, 2, 2 },
                    { 178, true, 78, 2, 2 },
                    { 179, true, 79, 2, 2 },
                    { 180, true, 80, 2, 2 },
                    { 181, true, 81, 2, 2 },
                    { 182, true, 82, 2, 2 },
                    { 183, true, 83, 2, 2 },
                    { 184, true, 84, 2, 2 },
                    { 185, true, 85, 2, 2 },
                    { 186, true, 86, 2, 2 },
                    { 187, true, 87, 2, 2 },
                    { 188, true, 88, 2, 2 },
                    { 189, true, 89, 2, 2 },
                    { 190, true, 90, 2, 2 },
                    { 191, true, 91, 2, 2 },
                    { 192, true, 92, 2, 2 },
                    { 193, true, 93, 2, 2 },
                    { 194, true, 94, 2, 2 },
                    { 195, true, 95, 2, 2 },
                    { 196, true, 96, 2, 2 },
                    { 197, true, 97, 2, 2 },
                    { 198, true, 98, 2, 2 },
                    { 199, true, 99, 2, 2 },
                    { 200, true, 100, 2, 2 },
                    { 201, true, 101, 2, 2 },
                    { 202, true, 102, 2, 2 },
                    { 203, true, 103, 2, 2 },
                    { 204, true, 104, 2, 2 },
                    { 205, true, 105, 2, 2 },
                    { 206, true, 106, 2, 2 },
                    { 207, true, 107, 2, 2 },
                    { 208, true, 108, 2, 2 },
                    { 209, true, 109, 2, 2 },
                    { 210, true, 110, 2, 2 },
                    { 211, true, 111, 2, 2 },
                    { 212, true, 112, 2, 2 },
                    { 213, true, 113, 2, 2 },
                    { 214, true, 114, 2, 2 },
                    { 215, true, 115, 2, 2 },
                    { 216, true, 116, 2, 2 },
                    { 217, true, 117, 2, 2 },
                    { 218, true, 118, 2, 2 },
                    { 219, true, 119, 2, 2 },
                    { 220, true, 120, 2, 2 },
                    { 221, true, 121, 2, 2 },
                    { 222, true, 122, 2, 2 },
                    { 223, true, 123, 2, 2 },
                    { 224, true, 124, 2, 2 },
                    { 225, true, 125, 2, 2 },
                    { 226, true, 126, 2, 2 },
                    { 227, true, 127, 2, 2 },
                    { 228, true, 128, 2, 2 },
                    { 229, true, 129, 2, 2 },
                    { 230, true, 130, 2, 2 },
                    { 231, true, 131, 2, 2 },
                    { 232, true, 132, 2, 2 },
                    { 233, true, 133, 2, 2 },
                    { 234, true, 134, 2, 2 },
                    { 235, true, 135, 2, 2 },
                    { 236, true, 136, 2, 2 },
                    { 237, true, 137, 2, 2 },
                    { 238, true, 138, 2, 2 },
                    { 239, true, 139, 2, 2 },
                    { 240, true, 140, 2, 2 },
                    { 241, true, 141, 2, 2 },
                    { 242, true, 142, 2, 2 },
                    { 243, true, 143, 2, 2 },
                    { 244, true, 144, 2, 2 },
                    { 245, true, 145, 2, 2 },
                    { 246, true, 146, 2, 2 },
                    { 247, true, 147, 2, 2 },
                    { 248, true, 148, 2, 2 },
                    { 249, true, 149, 2, 2 },
                    { 250, true, 150, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "ProjectionId", "SaleDateTime", "SeatId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 23, 17, 35, 31, 804, DateTimeKind.Local).AddTicks(7507), 1, "1" },
                    { 2, 2, new DateTime(2024, 7, 23, 17, 35, 31, 804, DateTimeKind.Local).AddTicks(7539), 2, "2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Projections_AdministratorId",
                table: "Projections",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projections_MovieId",
                table: "Projections",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Projections_ProjectionTypeId",
                table: "Projections",
                column: "ProjectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projections_TheaterId",
                table: "Projections",
                column: "TheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectionTypes_TheaterId",
                table: "ProjectionTypes",
                column: "TheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_ProjectionId",
                table: "Seats",
                column: "ProjectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_TheaterId",
                table: "Seats",
                column: "TheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectionId",
                table: "Tickets",
                column: "ProjectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Projections");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "ProjectionTypes");

            migrationBuilder.DropTable(
                name: "Theaters");
        }
    }
}
