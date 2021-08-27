using Microsoft.EntityFrameworkCore.Migrations;

namespace Cebulit.API.Migrations
{
    public partial class UserGeneratedBuildsOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserGeneratedBuildOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserGeneratedBuildId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGeneratedBuildOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGeneratedBuildOrder_UserBuilds_UserGeneratedBuildId",
                        column: x => x.UserGeneratedBuildId,
                        principalTable: "UserBuilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGeneratedBuildOrder_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGeneratedBuildOrder_UserGeneratedBuildId",
                table: "UserGeneratedBuildOrder",
                column: "UserGeneratedBuildId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGeneratedBuildOrder_UserId",
                table: "UserGeneratedBuildOrder",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGeneratedBuildOrder");
        }
    }
}
