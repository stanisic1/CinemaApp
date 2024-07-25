using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projections_AspNetUsers_AdministratorId",
                table: "Projections");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bca96ccf-aae6-40dc-a829-1739bf12478c", "AQAAAAIAAYagAAAAECPz5k4ZWbTOcYvc6sWzrdv4Pdaru58z5rNBzkYcgZE4dcLgz/gyjELYuhMGk9H1+A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7831a673-1f1c-4a61-90c0-38990b58bef3", "AQAAAAIAAYagAAAAEJiMjjx0Umblsx2/EW4pKn9aqFVi66HgiB3YhErqYFqbRFQGSBkZpcVsHsuiCjmRQA==" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 7, 25, 14, 20, 26, 812, DateTimeKind.Local).AddTicks(3967));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 7, 25, 14, 20, 26, 812, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 7, 25, 14, 20, 26, 812, DateTimeKind.Local).AddTicks(6128));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 7, 25, 14, 20, 26, 812, DateTimeKind.Local).AddTicks(6163));

            migrationBuilder.AddForeignKey(
                name: "FK_Projections_AspNetUsers_AdministratorId",
                table: "Projections",
                column: "AdministratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projections_AspNetUsers_AdministratorId",
                table: "Projections");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aa1e76d6-dbf6-47a2-89b3-5fe83d3d26c7", "AQAAAAIAAYagAAAAEMFQEmy2l+IBR2lrjNX9LUeuimHF9hf1rApFQZY8u37LUaZA4sCiFKY4ocUQb3/9rw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ebb94a65-3693-4fb3-b09b-5cc31dabf7a4", "AQAAAAIAAYagAAAAEHZgUfQKXh3k1BBOHKEXCIPOUu6JmIvjkWQ7gtxWeaZs4bgmxoeagA3WRiUQuiHj4A==" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 7, 25, 13, 6, 10, 59, DateTimeKind.Local).AddTicks(7061));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 7, 25, 13, 6, 10, 59, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 7, 25, 13, 6, 10, 59, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 7, 25, 13, 6, 10, 59, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.AddForeignKey(
                name: "FK_Projections_AspNetUsers_AdministratorId",
                table: "Projections",
                column: "AdministratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
