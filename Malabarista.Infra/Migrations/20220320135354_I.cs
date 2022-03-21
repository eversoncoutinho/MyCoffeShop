using Microsoft.EntityFrameworkCore.Migrations;

namespace Malabarista.Infra.Migrations
{
    public partial class I : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Grains",
                newName: "DateRegister");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateRegister",
                table: "Grains",
                newName: "DataCadastro");
        }
    }
}
