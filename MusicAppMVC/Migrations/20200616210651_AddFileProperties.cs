using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicAppMVC.Migrations
{
    public partial class AddFileProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "MusicFiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "MusicFiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MusicFiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "MusicFiles");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "MusicFiles");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "MusicFiles");
        }
    }
}
