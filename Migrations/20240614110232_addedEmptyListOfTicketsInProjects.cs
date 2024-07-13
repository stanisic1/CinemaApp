using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class addedEmptyListOfTicketsInProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b22e2680-5566-49ec-a9c5-4089c6c4ed56", "ba47049b-b65a-45a2-8599-5cbecffa5d56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6f328136-cce9-4d48-8888-40c920155b94", "6a586ead-70ad-4930-9cb2-6b76686c939b" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 6, 14, 13, 2, 31, 32, DateTimeKind.Local).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 6, 14, 13, 2, 31, 32, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 6, 14, 13, 2, 31, 32, DateTimeKind.Local).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 6, 14, 13, 2, 31, 32, DateTimeKind.Local).AddTicks(6991));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
