using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class bool_projection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Projections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

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
                columns: new[] { "DateTime", "IsDeleted" },
                values: new object[] { new DateTime(2024, 6, 12, 16, 42, 8, 606, DateTimeKind.Local).AddTicks(8868), false });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateTime", "IsDeleted" },
                values: new object[] { new DateTime(2024, 6, 12, 16, 42, 8, 606, DateTimeKind.Local).AddTicks(9024), false });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Projections");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Movies",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "40435bff-1da5-452c-a20f-219ba6e82264", "a5225ff1-c3bc-4172-9c4f-f62472411a75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "750b9770-a723-4e24-8480-868f4277bc15", "942f9f1d-4b99-49ca-8bdf-4eff6e72431c" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 6, 11, 12, 57, 59, 559, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 6, 11, 12, 57, 59, 559, DateTimeKind.Local).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 6, 11, 12, 57, 59, 559, DateTimeKind.Local).AddTicks(2808));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 6, 11, 12, 57, 59, 559, DateTimeKind.Local).AddTicks(2833));
        }
    }
}
