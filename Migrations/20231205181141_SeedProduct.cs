using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameHub.Migrations
{
    /// <inheritdoc />
    public partial class SeedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Gotcha! Coming in 2025 only for Ps5", 90.0, "GTA 6" },
                    { 2, "This game is not a metro simulator", 30.0, "Metro Exodus" },
                    { 3, "The goat", 20.0, "Assassin's Creed Unity" },
                    { 4, "The second best assassin's creed game", 40.0, "Assassin's Creed Origin" }
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
        }
    }
}
