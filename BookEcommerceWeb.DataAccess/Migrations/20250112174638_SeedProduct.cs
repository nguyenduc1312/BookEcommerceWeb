using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookEcommerceWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "CreatedDate", "Description", "ImageUrl", "Price", "Price100", "Price50", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Billy Spark", 1, new DateTime(2025, 1, 12, 17, 46, 38, 375, DateTimeKind.Utc).AddTicks(4539), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", null, 90.0, 80.0, 85.0, "Fortune of Time", null },
                    { 2, "Nancy Hoover", 1, new DateTime(2025, 1, 12, 17, 46, 38, 375, DateTimeKind.Utc).AddTicks(4543), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", null, 30.0, 20.0, 25.0, "Dark Skies", null },
                    { 3, "Julian Button", 1, new DateTime(2025, 1, 12, 17, 46, 38, 375, DateTimeKind.Utc).AddTicks(4545), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", null, 50.0, 35.0, 40.0, "Vanish in the Sunset", null },
                    { 4, "Abby Muscles", 2, new DateTime(2025, 1, 12, 17, 46, 38, 375, DateTimeKind.Utc).AddTicks(4547), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", null, 65.0, 55.0, 60.0, "Cotton Candy", null },
                    { 5, "Ron Parker", 2, new DateTime(2025, 1, 12, 17, 46, 38, 375, DateTimeKind.Utc).AddTicks(4548), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", null, 27.0, 20.0, 25.0, "Rock in the Ocean", null },
                    { 6, "Laura Phantom", 3, new DateTime(2025, 1, 12, 17, 46, 38, 375, DateTimeKind.Utc).AddTicks(4550), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", null, 23.0, 20.0, 22.0, "Leaves and Wonders", null }
                });
        }

        /// <inheritdoc />
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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
