using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicAppMVC.Migrations
{
    public partial class AddIsChecked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "MusicFiles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "MusicFiles");
        }
    }
}
