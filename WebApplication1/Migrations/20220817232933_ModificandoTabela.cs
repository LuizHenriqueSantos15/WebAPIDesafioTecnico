using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class ModificandoTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_Usuarios_AutorId",
                table: "Publicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Publicacoes_AutorId",
                table: "Publicacoes");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Publicacoes");

            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Publicacoes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Publicacoes");

            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Publicacoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_AutorId",
                table: "Publicacoes",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_Usuarios_AutorId",
                table: "Publicacoes",
                column: "AutorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
