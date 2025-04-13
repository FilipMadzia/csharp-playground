using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEntertainmentColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ColorHex",
                value: "#7DDA58");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ColorHex",
                value: "#98F5F9");
        }
    }
}
