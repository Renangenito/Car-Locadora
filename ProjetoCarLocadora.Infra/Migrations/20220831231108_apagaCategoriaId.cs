using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoCarLocadora.Infra.Migrations
{
    public partial class apagaCategoriaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacao_Categorias_CategoriaId",
                table: "Locacao");

            migrationBuilder.DropIndex(
                name: "IX_Locacao_CategoriaId",
                table: "Locacao");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Locacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Locacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_CategoriaId",
                table: "Locacao",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locacao_Categorias_CategoriaId",
                table: "Locacao",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
