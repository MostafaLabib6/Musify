using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Musify.MVC.Migrations
{
    public partial class AddTagandTypeforSong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tag",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Songs");
        }
    }
}
