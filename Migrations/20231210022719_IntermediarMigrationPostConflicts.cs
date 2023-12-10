using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameHub.Migrations
{
    /// <inheritdoc />
    public partial class IntermediarMigrationPostConflicts : Migration
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
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    MinOperatingSystem = table.Column<int>(type: "int", nullable: true),
                    RecomandedOperatingSystem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "ShoppingCartProductContract",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartProductContract", x => new { x.ProductsId, x.ShoppingCartsId });
                    table.ForeignKey(
                        name: "FK_ShoppingCartProductContract_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartProductContract_ShoppingCarts_ShoppingCartsId",
                        column: x => x.ShoppingCartsId,
                        principalTable: "ShoppingCarts",
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
                columns: new[] { "Id", "Description", "Image", "MinOperatingSystem", "Platform", "Price", "RecomandedOperatingSystem", "Stock", "Title", "Video" },
                values: new object[,]
                {
                    { 1, "Gotcha! Coming in 2025 only for Ps5", "https://cdn.images.express.co.uk/img/dynamic/143/590x/secondary/GTA-6-trailer-Grand-Theft-Auto-6-gameplay-reveal-5098949.jpg?r=1701793274244", null, 1, 90.0, null, 0, "GTA 6", null },
                    { 2, "This game is not a metro simulator", null, null, 3, 30.0, null, 23, "Metro Exodus", null },
                    { 3, "The goat", "https://upload.wikimedia.org/wikipedia/en/thumb/4/41/Assassin%27s_Creed_Unity_cover.jpg/220px-Assassin%27s_Creed_Unity_cover.jpg", null, 2, 20.0, null, 13, "Assassin's Creed Unity", null },
                    { 4, "The second best assassin's creed game", "https://upload.wikimedia.org/wikipedia/en/4/4a/Assassin%27s_Creed_Origins_Cover_Art.png", null, 4, 40.0, null, 10, "Assassin's Creed Origin", null },
                    { 5, "Racing game", "https://image.api.playstation.com/cdn/EP0001/CUSA00161_00/f0kLJbch2vDawClFcF6k9LzZ7Ohi9a7n.png", 1, 5, 15.0, 4, 23, "The Crew", null },
                    { 6, "This doesn't need a description", null, 1, 5, 25.0, 4, 6, "Minecraft", null }
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

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartProductContract_ShoppingCartsId",
                table: "ShoppingCartProductContract",
                column: "ShoppingCartsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategoryContract");

            migrationBuilder.DropTable(
                name: "ShoppingCartProductContract");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");
        }
    }
}
