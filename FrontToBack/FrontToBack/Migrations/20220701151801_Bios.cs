using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontToBack.Migrations
{
    public partial class Bios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorNmae",
                table: "Bios");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Bios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Bios");

            migrationBuilder.AddColumn<string>(
                name: "AuthorNmae",
                table: "Bios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
