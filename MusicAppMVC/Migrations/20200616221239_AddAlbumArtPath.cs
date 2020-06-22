using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicAppMVC.Migrations
{
    public partial class AddAlbumArtPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlbumArtPath",
                table: "MusicFiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbumArtPath",
                table: "MusicFiles");
        }
    }
}
