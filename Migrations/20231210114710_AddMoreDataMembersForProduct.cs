using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameHub.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreDataMembersForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvailableLanguages",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MultiplayerInfo",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Producer",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RecomandedAge",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableLanguages", "MultiplayerInfo", "Producer", "RecomandedAge", "ReleaseDate" },
                values: new object[] { "[\"English\",\"French\",\"German\",\"Japanese\"]", "Co-op: 1-30 players", "Rockstar", 17, "12 october 2025" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableLanguages", "MultiplayerInfo", "Producer", "RecomandedAge", "ReleaseDate" },
                values: new object[] { "[\"English\",\"French\",\"German\"]", "No multiplayer - Single player experience", "Deep Silver", 15, "30 june 2019" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableLanguages", "MultiplayerInfo", "Producer", "RecomandedAge", "ReleaseDate" },
                values: new object[] { "[\"English\",\"French\",\"German\"]", "Co-op: 2-4 players", "Ubisoft Connect", 12, "2 may 2014" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableLanguages", "MultiplayerInfo", "Producer", "RecomandedAge", "ReleaseDate" },
                values: new object[] { "[\"English\",\"French\",\"German\",\"Japanese\",\"Turkish\"]", "No multiplayer - only single player experience", "Ubisoft Connect", 12, "18 december 2017" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvailableLanguages", "MultiplayerInfo", "Producer", "RecomandedAge", "ReleaseDate" },
                values: new object[] { "[\"English\",\"French\",\"German\",\"Japanese\",\"Turkish\"]", "Co-op: up to 32 players", "Ubisoft", null, "22 july 2020" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AvailableLanguages", "MultiplayerInfo", "Producer", "RecomandedAge", "ReleaseDate" },
                values: new object[] { "[\"English\"]", "Public server - no limit for players", "Sandbox", 4, "8 january 2010" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableLanguages",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MultiplayerInfo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Producer",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecomandedAge",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Products");
        }
    }
}
