using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedContactTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "CreatedDate", "Email", "FullName", "ImageUrl", "MobilePhone" },
                values: new object[,]
                {
                    { 1, "456 Elm Street", new DateTime(2023, 3, 30, 18, 50, 31, 365, DateTimeKind.Local).AddTicks(1672), "janesmith@example.com", "Jane Smith", "https://example.com/janesmith.jpg", "09087654321" },
                    { 2, "123 Main Street", new DateTime(2023, 3, 30, 18, 50, 31, 365, DateTimeKind.Local).AddTicks(1689), "johndoe@example.com", "John Doe", "https://example.com/johndoe.jpg", "08012345678" },
                    { 3, "789 Oak Street", new DateTime(2023, 3, 30, 18, 50, 31, 365, DateTimeKind.Local).AddTicks(1691), "bobjohnson@example.com", "Bob Johnson", "https://example.com/bobjohnson.jpg", "07011223344" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
