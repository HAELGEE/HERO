using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HERO.Migrations
{
    /// <inheritdoc />
    public partial class Update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Agility",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Armor",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Charm",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentHealth",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Damage",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Healing",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Intelligence",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Lifesteal",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxHealth",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Resistance",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stamina",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Strength",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subclass",
                table: "Enemy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Weakness",
                table: "Enemy",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agility",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "Armor",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "Charm",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "CurrentHealth",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "Damage",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "Healing",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "Intelligence",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "Lifesteal",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "MaxHealth",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "Resistance",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "Stamina",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "Strength",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "Subclass",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "Weakness",
                table: "Enemy");
        }
    }
}
