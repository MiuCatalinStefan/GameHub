using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameHub.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAllVideosSrcMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Video",
                value: "https://www.youtube.com/embed/QdBZY2fkU-0?si=xAkI1IZSKdli1kjn");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Video",
                value: "https://www.youtube.com/embed/fbbqlvuovQ0?si=5D3_u86XU3mCToDA");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Video",
                value: "https://www.youtube.com/embed/xzCEdSKMkdU?si=5CNvTX67tXPcOD00");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Video",
                value: "https://www.youtube.com/embed/cK4iAjzAoas?si=7QKTeylLWgXXMRQT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Video",
                value: "https://www.youtube.com/watch?v=QdBZY2fkU-0&t=5s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Video",
                value: "https://www.youtube.com/watch?v=fbbqlvuovQ0");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Video",
                value: "https://www.youtube.com/watch?v=fbbqlvuovQ0");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Video",
                value: "https://www.youtube.com/watch?v=cK4iAjzAoas");
        }
    }
}
