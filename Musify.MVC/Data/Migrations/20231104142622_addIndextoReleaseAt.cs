using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Musify.MVC.Migrations
{
    public partial class addIndextoReleaseAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Songs_ReleaseAt",
                table: "Songs",
                column: "ReleaseAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Songs_ReleaseAt",
                table: "Songs");
        }
    }
}
