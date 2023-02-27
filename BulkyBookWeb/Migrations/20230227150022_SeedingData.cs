using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBookWeb.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDataTime", "Price", "Quantiy", "Title" },
                values: new object[] { 1, new DateTime(2023, 2, 27, 20, 0, 22, 149, DateTimeKind.Local).AddTicks(8400), 74.090000000000003, 55.0, "HDD 1TB" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDataTime", "Price", "Quantiy", "Title" },
                values: new object[] { 2, new DateTime(2023, 2, 27, 20, 0, 22, 149, DateTimeKind.Local).AddTicks(8413), 190.99000000000001, 102.0, "HDD SSD 512GB" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDataTime", "Price", "Quantiy", "Title" },
                values: new object[] { 3, new DateTime(2023, 2, 27, 20, 0, 22, 149, DateTimeKind.Local).AddTicks(8415), 80.319999999999993, 47.0, "RAM DDR4 16GB " });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
