using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HERO.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "SubclassId",
                table: "Enemy");

            migrationBuilder.RenameColumn(
                name: "Subclass",
                table: "Enemy",
                newName: "Race");

            migrationBuilder.AlterColumn<int>(
                name: "MaxXP",
                table: "Hero",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "Hero",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentXP",
                table: "Hero",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BaseDamage",
                table: "Hero",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalSpeed",
                table: "Hero",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Turn",
                table: "Hero",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TotalSpeed",
                table: "Enemy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Turn",
                table: "Enemy",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseDamage",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "TotalSpeed",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "Turn",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "TotalSpeed",
                table: "Enemy");

            migrationBuilder.DropColumn(
                name: "Turn",
                table: "Enemy");

            migrationBuilder.RenameColumn(
                name: "Race",
                table: "Enemy",
                newName: "Subclass");

            migrationBuilder.AlterColumn<int>(
                name: "MaxXP",
                table: "Hero",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "Hero",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentXP",
                table: "Hero",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
