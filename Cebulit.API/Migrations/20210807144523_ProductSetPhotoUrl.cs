using Microsoft.EntityFrameworkCore.Migrations;

namespace Cebulit.API.Migrations
{
    public partial class ProductSetPhotoUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "UserBuilds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Builds",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "UserBuilds");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Builds");
        }
    }
}
