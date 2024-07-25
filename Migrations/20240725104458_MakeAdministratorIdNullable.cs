using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class MakeAdministratorIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0693bd91-7741-4a9d-ab35-ff20c5a81985", "AQAAAAIAAYagAAAAECr9IvlgKvhYnCc0oFGjxb0TuTEhc+0SnDBR7VJ3mv8jiRB13LH6UoPwxYkuNhmdLQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "faf3580b-7ddb-4d42-be7a-b6bb98c69ca7", "AQAAAAIAAYagAAAAEGQf+2KBrR/+XzPgUQH6nlyTqfyQ7A8nGZxnN6aCcwAtaE/gATdMBoGVUCCjdycnsQ==" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 7, 23, 17, 35, 31, 804, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 7, 23, 17, 35, 31, 804, DateTimeKind.Local).AddTicks(5551));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 7, 23, 17, 35, 31, 804, DateTimeKind.Local).AddTicks(7507));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 7, 23, 17, 35, 31, 804, DateTimeKind.Local).AddTicks(7539));
        }
    }
}
