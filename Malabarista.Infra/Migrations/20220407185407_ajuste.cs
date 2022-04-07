using Microsoft.EntityFrameworkCore.Migrations;

namespace Malabarista.Infra.Migrations
{
    public partial class ajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PronouncedNote",
                table: "Tastes",
                newName: "GrainNotes_PronouncedNote");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GrainNotes_PronouncedNote",
                table: "Tastes",
                newName: "PronouncedNote");
        }
    }
}
