using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameHub.Migrations
{
    /// <inheritdoc />
    public partial class Region : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecomandedRam",
                table: "Products",
                newName: "RecommendedRam");

            migrationBuilder.RenameColumn(
                name: "RecomandedProcessor",
                table: "Products",
                newName: "RecommendedProcessor");

            migrationBuilder.RenameColumn(
                name: "RecomandedOperatingSystem",
                table: "Products",
                newName: "RecommendedOperatingSystem");

            migrationBuilder.RenameColumn(
                name: "RecomandedGraphic",
                table: "Products",
                newName: "RecommendedGraphic");

            migrationBuilder.RenameColumn(
                name: "RecomandedAge",
                table: "Products",
                newName: "RecommendedAge");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RecommendedAge", "RegionId" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RecommendedAge", "RegionId" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "RecommendedAge", "RegionId" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "RecommendedAge", "RegionId" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "RecommendedGraphic", "RecommendedOperatingSystem", "RecommendedProcessor", "RecommendedRam", "RegionId" },
                values: new object[] { null, null, null, null, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "RecommendedAge", "RecommendedGraphic", "RecommendedOperatingSystem", "RecommendedProcessor", "RecommendedRam", "RegionId" },
                values: new object[] { null, null, null, null, null, 1 });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Europe" },
                    { 2, "USA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_RegionId",
                table: "Products",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Regions_RegionId",
                table: "Products",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Regions_RegionId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Products_RegionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "RecommendedRam",
                table: "Products",
                newName: "RecomandedRam");

            migrationBuilder.RenameColumn(
                name: "RecommendedProcessor",
                table: "Products",
                newName: "RecomandedProcessor");

            migrationBuilder.RenameColumn(
                name: "RecommendedOperatingSystem",
                table: "Products",
                newName: "RecomandedOperatingSystem");

            migrationBuilder.RenameColumn(
                name: "RecommendedGraphic",
                table: "Products",
                newName: "RecomandedGraphic");

            migrationBuilder.RenameColumn(
                name: "RecommendedAge",
                table: "Products",
                newName: "RecomandedAge");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecomandedAge",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecomandedAge",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecomandedAge",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "RecomandedAge",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "RecomandedGraphic", "RecomandedOperatingSystem", "RecomandedProcessor", "RecomandedRam" },
                values: new object[] { 4, 4, 1, 32 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "RecomandedAge", "RecomandedGraphic", "RecomandedOperatingSystem", "RecomandedProcessor", "RecomandedRam" },
                values: new object[] { 4, 3, 4, 5, 16 });
        }
    }
}
