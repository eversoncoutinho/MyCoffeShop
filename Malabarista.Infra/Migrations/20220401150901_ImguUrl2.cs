using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Malabarista.Infra.Migrations
{
    public partial class ImguUrl2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "GrainChar_ImgUrl",
                table: "Grains",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "GrainChar_ImgUrl",
                table: "Grains",
                type: "tinyint unsigned",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);
        }
    }
}
