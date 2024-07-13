using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class BoolInMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Movies",
                type: "bit",
                nullable: true);

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
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Movies");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bbdb80be-8239-4e69-8e62-3e485bfd01ce", "da6f6c35-57d6-45f7-8cb7-5f7eae8e7b07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4c005e87-fbc0-4979-9a95-441245eb0f93", "6f625d6d-1523-4b4b-a7a5-f8af65018c70" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 5, 21, 16, 29, 32, 330, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 5, 21, 16, 29, 32, 330, DateTimeKind.Local).AddTicks(7783));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 5, 21, 16, 29, 32, 330, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 5, 21, 16, 29, 32, 330, DateTimeKind.Local).AddTicks(7911));
        }
    }
}
