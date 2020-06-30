using Microsoft.EntityFrameworkCore.Migrations;

namespace meii.infrastructure.Migrations
{
    public partial class AlterFieldDescricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descrição",
                table: "produto");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "produto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "produto");

            migrationBuilder.AddColumn<string>(
                name: "Descrição",
                table: "produto",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
