using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class ProjectionTypeEnumAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProjectionTypes");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ProjectionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                table: "ProjectionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProjectionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProjectionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 3);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ProjectionTypes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProjectionTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "af73473c-c99b-49d6-989c-2de1968a3e56", "649dc351-15ce-43dd-8c48-f17022fe773c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "33e415e3-d9d0-4f2f-9a8d-b55459941afe", "077bb310-147a-4401-b99a-72e0100fdbbd" });

            migrationBuilder.UpdateData(
                table: "ProjectionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "2D");

            migrationBuilder.UpdateData(
                table: "ProjectionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "3D");

            migrationBuilder.UpdateData(
                table: "ProjectionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "4D");

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 5, 21, 11, 10, 16, 416, DateTimeKind.Local).AddTicks(2555));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 5, 21, 11, 10, 16, 416, DateTimeKind.Local).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 5, 21, 11, 10, 16, 416, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 5, 21, 11, 10, 16, 416, DateTimeKind.Local).AddTicks(2820));
        }
    }
}
