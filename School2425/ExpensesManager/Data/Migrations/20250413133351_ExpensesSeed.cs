using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpensesManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExpensesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "CategoryId", "Date", "Name" },
                values: new object[,]
                {
                    { 1, 12.99m, 1, new DateOnly(2025, 1, 1), "Jogurty" },
                    { 2, 11.50m, 1, new DateOnly(2025, 1, 2), "Mega Rollo Kebab" },
                    { 3, 193.12m, 2, new DateOnly(2025, 1, 3), "Prąd" },
                    { 4, 32.99m, 2, new DateOnly(2025, 1, 4), "Abonament za telefon" },
                    { 5, 99.99m, 3, new DateOnly(2025, 1, 5), "T-Shirt" },
                    { 6, 139.99m, 3, new DateOnly(2025, 1, 6), "Spodnie" },
                    { 7, 29.99m, 4, new DateOnly(2025, 1, 7), "Kino" },
                    { 8, 1299m, 4, new DateOnly(2025, 1, 8), "Lot helikopterem" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
