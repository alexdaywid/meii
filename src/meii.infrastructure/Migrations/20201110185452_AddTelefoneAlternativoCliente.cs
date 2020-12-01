using Microsoft.EntityFrameworkCore.Migrations;

namespace meii.infrastructure.Migrations
{
    public partial class AddTelefoneAlternativoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelefoneFixo",
                table: "Pessoas");

            migrationBuilder.AddColumn<string>(
                name: "TelefoneAlternativo",
                table: "Pessoas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelefoneAlternativo",
                table: "Pessoas");

            migrationBuilder.AddColumn<string>(
                name: "TelefoneFixo",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
