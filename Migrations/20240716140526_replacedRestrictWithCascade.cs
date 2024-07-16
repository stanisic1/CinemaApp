using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class replacedRestrictWithCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projections_ProjectionId",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9e239f9f-2393-4606-9566-a5abcd6448a5", "809adc98-cc0a-45b7-870d-d90f6ec9a16b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "99c1b66a-409a-481c-b2e1-7dce08ba4f5e", "da1b7c42-2640-4d45-bfc9-ce7440d7975d" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 7, 16, 16, 5, 24, 733, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 7, 16, 16, 5, 24, 733, DateTimeKind.Local).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 7, 16, 16, 5, 24, 733, DateTimeKind.Local).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 7, 16, 16, 5, 24, 733, DateTimeKind.Local).AddTicks(7827));

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projections_ProjectionId",
                table: "Tickets",
                column: "ProjectionId",
                principalTable: "Projections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projections_ProjectionId",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b1603170-615f-4ba6-a509-80920b7f57fb", "93d7e55a-7249-47f6-8ba2-5ee54c379c14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5b5b003c-9b9c-43d8-b4d1-3e981693c681", "524946d7-7f78-46df-b20c-ed6ac56545cf" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 7, 16, 15, 54, 7, 426, DateTimeKind.Local).AddTicks(3291));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 7, 16, 15, 54, 7, 426, DateTimeKind.Local).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 7, 16, 15, 54, 7, 426, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 7, 16, 15, 54, 7, 426, DateTimeKind.Local).AddTicks(3590));

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projections_ProjectionId",
                table: "Tickets",
                column: "ProjectionId",
                principalTable: "Projections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
