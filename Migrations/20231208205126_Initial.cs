using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameHub.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryContract",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryContract", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductCategoryContract_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoryContract_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "RPG" },
                    { 2, "Adventure" },
                    { 3, "Action" },
                    { 4, "Strategy" },
                    { 5, "Third Person Shooter" },
                    { 6, "First Person Shooter" },
                    { 7, "Racing" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Gotcha! Coming in 2025 only for Ps5", "https://cdn.images.express.co.uk/img/dynamic/143/590x/secondary/GTA-6-trailer-Grand-Theft-Auto-6-gameplay-reveal-5098949.jpg?r=1701793274244", 90.0, "GTA 6" },
                    { 2, "This game is not a metro simulator", null, 30.0, "Metro Exodus" },
                    { 3, "The goat", "https://upload.wikimedia.org/wikipedia/en/thumb/4/41/Assassin%27s_Creed_Unity_cover.jpg/220px-Assassin%27s_Creed_Unity_cover.jpg", 20.0, "Assassin's Creed Unity" },
                    { 4, "The second best assassin's creed game", "https://upload.wikimedia.org/wikipedia/en/4/4a/Assassin%27s_Creed_Origins_Cover_Art.png", 40.0, "Assassin's Creed Origin" },
                    { 5, "Racing game", "https://image.api.playstation.com/cdn/EP0001/CUSA00161_00/f0kLJbch2vDawClFcF6k9LzZ7Ohi9a7n.png", 15.0, "The Crew" },
                    { 6, "This doesn't need a description", null, 25.0, "Minecraft" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategoryContract",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 6 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 5, 1 },
                    { 6, 2 },
                    { 7, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryContract_ProductsId",
                table: "ProductCategoryContract",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategoryContract");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
