using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HERO.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Enemy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubclassId",
                table: "Enemy",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "SubclassId",
                table: "Enemy");
        }
    }
}
