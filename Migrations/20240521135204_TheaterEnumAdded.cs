using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class TheaterEnumAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Theaters");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Theaters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0f649841-7627-4d72-94f0-21378f13bedd", "84932d5b-1ad6-4e19-990b-50237d5fb000" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "92abebc2-908a-4d6f-9765-62e4bf938114", "299b67e5-3ccd-46ea-bbd9-1229c67db24e" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 5, 21, 15, 52, 3, 517, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 5, 21, 15, 52, 3, 517, DateTimeKind.Local).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 5, 21, 15, 52, 3, 517, DateTimeKind.Local).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 5, 21, 15, 52, 3, 517, DateTimeKind.Local).AddTicks(4565));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Theaters");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Theaters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b1e0baf2-e59c-4516-b884-232ce726e4cd", "7b9c15b2-bfb7-449a-9ea5-6eb2eaaf28d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "014b0cd8-cb16-413d-add1-2d374f1b89e1", "463ceb36-adbf-4ea2-8896-24758108e2f4" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 5, 21, 15, 19, 5, 839, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 5, 21, 15, 19, 5, 839, DateTimeKind.Local).AddTicks(8319));

            migrationBuilder.UpdateData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Movie House");

            migrationBuilder.UpdateData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Theater Hall");

            migrationBuilder.UpdateData(
                table: "Theaters",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Picture Dream");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 5, 21, 15, 19, 5, 839, DateTimeKind.Local).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 5, 21, 15, 19, 5, 839, DateTimeKind.Local).AddTicks(8585));
        }
    }
}
