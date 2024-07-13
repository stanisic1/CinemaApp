using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class againMoviIdInProjectionDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "51509ab4-2b5f-49b9-bcff-80542cb4c54c", "93f9f7e6-551b-4efe-ae4c-8620e40d0131" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2518cf9a-de40-441b-b8a2-b7859454b127", "f12c9831-df71-4f81-9f9a-e233566565f9" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 6, 16, 16, 19, 29, 513, DateTimeKind.Local).AddTicks(7467));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 6, 16, 16, 19, 29, 513, DateTimeKind.Local).AddTicks(7598));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 6, 16, 16, 19, 29, 513, DateTimeKind.Local).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 6, 16, 16, 19, 29, 513, DateTimeKind.Local).AddTicks(7723));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
