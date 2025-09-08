using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HERO.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cheast",
                table: "Hero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Feet",
                table: "Hero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Hands",
                table: "Hero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Head",
                table: "Hero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Legs",
                table: "Hero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weapon",
                table: "Hero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GearSlot",
                table: "Armor",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cheast",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "Feet",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "Hands",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "Head",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "Legs",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "Weapon",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "GearSlot",
                table: "Armor");
        }
    }
}
