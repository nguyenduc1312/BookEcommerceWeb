using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookEcommerceWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 9, 26, 163, DateTimeKind.Utc).AddTicks(9242), new DateTime(2025, 1, 12, 16, 9, 26, 163, DateTimeKind.Utc).AddTicks(9243) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 9, 26, 163, DateTimeKind.Utc).AddTicks(9245), new DateTime(2025, 1, 12, 16, 9, 26, 163, DateTimeKind.Utc).AddTicks(9245) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 9, 26, 163, DateTimeKind.Utc).AddTicks(9247), new DateTime(2025, 1, 12, 16, 9, 26, 163, DateTimeKind.Utc).AddTicks(9247) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 9, 26, 163, DateTimeKind.Utc).AddTicks(9248), new DateTime(2025, 1, 12, 16, 9, 26, 163, DateTimeKind.Utc).AddTicks(9249) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 9, 26, 163, DateTimeKind.Utc).AddTicks(9250), new DateTime(2025, 1, 12, 16, 9, 26, 163, DateTimeKind.Utc).AddTicks(9250) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Categories");
        }
    }
}
