using Microsoft.EntityFrameworkCore.Migrations;

namespace Malabarista.Infra.Migrations
{
    public partial class ondelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grains_Tastes_TasteId",
                table: "Grains");

            migrationBuilder.AddForeignKey(
                name: "FK_Grains_Tastes_TasteId",
                table: "Grains",
                column: "TasteId",
                principalTable: "Tastes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grains_Tastes_TasteId",
                table: "Grains");

            migrationBuilder.AddForeignKey(
                name: "FK_Grains_Tastes_TasteId",
                table: "Grains",
                column: "TasteId",
                principalTable: "Tastes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
