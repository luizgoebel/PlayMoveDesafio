using Microsoft.EntityFrameworkCore.Migrations;

namespace PlayMoveDesafioProject.Migrations
{
    public partial class crudCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Empresas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FornecedorId",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
