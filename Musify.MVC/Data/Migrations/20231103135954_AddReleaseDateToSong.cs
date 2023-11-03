using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Musify.MVC.Migrations
{
    public partial class AddReleaseDateToSong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseAt",
                table: "Songs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseAt",
                table: "Songs");
        }
    }
}
