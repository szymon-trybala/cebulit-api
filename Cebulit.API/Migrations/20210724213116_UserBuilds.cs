using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cebulit.API.Migrations
{
    public partial class UserBuilds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserBuildId",
                table: "Storage",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserBuilds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GeneratedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProcessorId = table.Column<int>(type: "INTEGER", nullable: false),
                    MotherboardId = table.Column<int>(type: "INTEGER", nullable: false),
                    MemoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    GraphicsCardId = table.Column<int>(type: "INTEGER", nullable: true),
                    PowerSupplyId = table.Column<int>(type: "INTEGER", nullable: false),
                    CaseId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBuilds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBuilds_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBuilds_GraphicsCards_GraphicsCardId",
                        column: x => x.GraphicsCardId,
                        principalTable: "GraphicsCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBuilds_Memory_MemoryId",
                        column: x => x.MemoryId,
                        principalTable: "Memory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBuilds_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBuilds_PowerSupplies_PowerSupplyId",
                        column: x => x.PowerSupplyId,
                        principalTable: "PowerSupplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBuilds_Processors_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "Processors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBuilds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Storage_UserBuildId",
                table: "Storage",
                column: "UserBuildId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuilds_CaseId",
                table: "UserBuilds",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuilds_GraphicsCardId",
                table: "UserBuilds",
                column: "GraphicsCardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuilds_MemoryId",
                table: "UserBuilds",
                column: "MemoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuilds_MotherboardId",
                table: "UserBuilds",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuilds_PowerSupplyId",
                table: "UserBuilds",
                column: "PowerSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuilds_ProcessorId",
                table: "UserBuilds",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuilds_UserId",
                table: "UserBuilds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Storage_UserBuilds_UserBuildId",
                table: "Storage",
                column: "UserBuildId",
                principalTable: "UserBuilds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Storage_UserBuilds_UserBuildId",
                table: "Storage");

            migrationBuilder.DropTable(
                name: "UserBuilds");

            migrationBuilder.DropIndex(
                name: "IX_Storage_UserBuildId",
                table: "Storage");

            migrationBuilder.DropColumn(
                name: "UserBuildId",
                table: "Storage");
        }
    }
}
