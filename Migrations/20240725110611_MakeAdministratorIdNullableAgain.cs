using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class MakeAdministratorIdNullableAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdministratorId",
                table: "Projections",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdministratorId",
                table: "Projections",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dec55bed-6a58-4e56-9d7d-4fd165f7c4b3", "AQAAAAIAAYagAAAAELoRuRY2544pI01KYEoDQujcT5UVY71x9Y5wceZoAmOW24D+LDSoQiN2UEsLr48/uw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9038d6e2-a6e9-45ec-9658-18938b895c40", "AQAAAAIAAYagAAAAEEwMC3hFP89sVF3OO1Aex4bUWUuCOeVgOjoq53zLMl9rikJn5Jl6JCNgx0DvezBSVw==" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 7, 25, 12, 44, 57, 73, DateTimeKind.Local).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 7, 25, 12, 44, 57, 73, DateTimeKind.Local).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 7, 25, 12, 44, 57, 74, DateTimeKind.Local).AddTicks(538));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 7, 25, 12, 44, 57, 74, DateTimeKind.Local).AddTicks(574));
        }
    }
}
