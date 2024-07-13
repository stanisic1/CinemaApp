using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class remove_moviIdInProjectionDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1f2d7060-8103-4269-a5a3-7a6f702e2388", "7f2ed3b2-acc3-48c7-9acc-125e19cb8226" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "041b01f8-ef64-4d84-8c62-6b7c68b4f385", "78d69f2f-516b-41ba-b374-68a36712c060" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 6, 13, 11, 17, 19, 275, DateTimeKind.Local).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 6, 13, 11, 17, 19, 275, DateTimeKind.Local).AddTicks(2881));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 6, 13, 11, 17, 19, 275, DateTimeKind.Local).AddTicks(3204));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 6, 13, 11, 17, 19, 275, DateTimeKind.Local).AddTicks(3242));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "91aba645-409e-4069-8b25-c5920339cf56", "5082c604-3523-442e-8bb7-887e6d1ea6b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cc3fb098-9043-45bb-9cfe-a6c273257514", "41c38274-c7bc-4d44-83d4-ea2044c2014e" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 6, 12, 16, 42, 8, 606, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 6, 12, 16, 42, 8, 606, DateTimeKind.Local).AddTicks(9024));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 6, 12, 16, 42, 8, 606, DateTimeKind.Local).AddTicks(9188));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 6, 12, 16, 42, 8, 606, DateTimeKind.Local).AddTicks(9218));
        }
    }
}
