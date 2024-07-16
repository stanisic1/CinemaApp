using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class cascadeInstedRestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projections_AspNetUsers_AdministratorId",
                table: "Projections");

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
                name: "FK_Projections_AspNetUsers_AdministratorId",
                table: "Projections",
                column: "AdministratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projections_AspNetUsers_AdministratorId",
                table: "Projections");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "11fcdc85-98cf-4687-8f0f-eca6820501ab", "a4c2eabf-5c8f-4021-b246-24751ac048cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a2982423-d097-4d7c-a906-a736171aa005", "2808591e-a45e-4f34-8dc4-7ce9411b474f" });

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 6, 19, 17, 54, 25, 992, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 6, 19, 17, 54, 25, 992, DateTimeKind.Local).AddTicks(6800));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDateTime",
                value: new DateTime(2024, 6, 19, 17, 54, 25, 992, DateTimeKind.Local).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDateTime",
                value: new DateTime(2024, 6, 19, 17, 54, 25, 992, DateTimeKind.Local).AddTicks(7002));

            migrationBuilder.AddForeignKey(
                name: "FK_Projections_AspNetUsers_AdministratorId",
                table: "Projections",
                column: "AdministratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
