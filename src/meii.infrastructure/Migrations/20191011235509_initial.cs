using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace meii.infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empreendedores",
                columns: table => new
                {
                    EmpreendedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empreendedores", x => x.EmpreendedorId);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    TelefoneFixo = table.Column<string>(nullable: true),
                    TelefoneCelular = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    Rg = table.Column<string>(nullable: true),
                    DtNascimento = table.Column<DateTime>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true),
                    InscMunicipal = table.Column<string>(nullable: true),
                    InscEstadual = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    PessoaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    PessoaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PessoaId",
                table: "Clientes",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PessoaId",
                table: "Enderecos",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empreendedores");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
