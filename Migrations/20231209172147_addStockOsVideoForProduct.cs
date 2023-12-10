using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameHub.Migrations
{
    /// <inheritdoc />
    public partial class addStockOsVideoForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinOperatingSystem",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecomandedOperatingSystem",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MinOperatingSystem", "Platform", "RecomandedOperatingSystem", "Stock", "Video" },
                values: new object[] { 1, 1, 4, 120, "https://youtu.be/QdBZY2fkU-0" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MinOperatingSystem", "RecomandedOperatingSystem", "Stock", "Video" },
                values: new object[] { 2, 2, 23, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MinOperatingSystem", "RecomandedOperatingSystem", "Stock", "Video" },
                values: new object[] { null, null, 13, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MinOperatingSystem", "RecomandedOperatingSystem", "Stock", "Video" },
                values: new object[] { null, null, 10, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MinOperatingSystem", "RecomandedOperatingSystem", "Stock", "Video" },
                values: new object[] { 1, 4, 23, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MinOperatingSystem", "RecomandedOperatingSystem", "Stock", "Video" },
                values: new object[] { 1, 4, 6, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinOperatingSystem",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecomandedOperatingSystem",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Platform",
                value: 3);
        }
    }
}
