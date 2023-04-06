using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAPI.Migrations
{
    /// <inheritdoc />
    public partial class FirstNewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "298cde2c-2e77-446d-9f59-1e5151b934f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd2b739d-160c-483e-97eb-766f0ff5b8fe");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 5, 17, 29, 28, 44, DateTimeKind.Local).AddTicks(1695));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 5, 17, 29, 28, 44, DateTimeKind.Local).AddTicks(1711));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 5, 17, 29, 28, 44, DateTimeKind.Local).AddTicks(1713));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "298cde2c-2e77-446d-9f59-1e5151b934f7", "1", "Admin", "Admin" },
                    { "cd2b739d-160c-483e-97eb-766f0ff5b8fe", "2", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 5, 15, 8, 12, 554, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 5, 15, 8, 12, 554, DateTimeKind.Local).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 5, 15, 8, 12, 554, DateTimeKind.Local).AddTicks(3926));
        }
    }
}
