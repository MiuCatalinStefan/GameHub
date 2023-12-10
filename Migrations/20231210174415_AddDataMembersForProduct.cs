using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameHub.Migrations
{
    /// <inheritdoc />
    public partial class AddDataMembersForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinGraphic",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinProcessor",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinRam",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecomandedGraphic",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecomandedProcessor",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecomandedRam",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorageMemory",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MinGraphic", "MinProcessor", "MinRam", "RecomandedGraphic", "RecomandedProcessor", "RecomandedRam", "StorageMemory" },
                values: new object[] { null, null, null, null, null, null, 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MinGraphic", "MinProcessor", "MinRam", "MultiplayerInfo", "RecomandedGraphic", "RecomandedProcessor", "RecomandedRam", "StorageMemory" },
                values: new object[] { null, null, null, "only single player", null, null, null, 60 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MinGraphic", "MinProcessor", "MinRam", "RecomandedGraphic", "RecomandedProcessor", "RecomandedRam", "StorageMemory" },
                values: new object[] { null, null, null, null, null, null, 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MinGraphic", "MinProcessor", "MinRam", "MultiplayerInfo", "RecomandedGraphic", "RecomandedProcessor", "RecomandedRam", "StorageMemory" },
                values: new object[] { null, null, null, "only single player", null, null, null, 89 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MinGraphic", "MinProcessor", "MinRam", "RecomandedGraphic", "RecomandedProcessor", "RecomandedRam", "StorageMemory" },
                values: new object[] { 2, 2, 16, 4, 1, 32, 88 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MinGraphic", "MinProcessor", "MinRam", "MultiplayerInfo", "RecomandedGraphic", "RecomandedProcessor", "RecomandedRam", "StorageMemory" },
                values: new object[] { 1, 4, 8, "Public server", 3, 5, 16, 7 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinGraphic",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinProcessor",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinRam",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecomandedGraphic",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecomandedProcessor",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecomandedRam",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StorageMemory",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "MultiplayerInfo",
                value: "No multiplayer - Single player experience");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "MultiplayerInfo",
                value: "No multiplayer - only single player experience");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "MultiplayerInfo",
                value: "Public server - no limit for players");
        }
    }
}
