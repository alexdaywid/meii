using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace meii.infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titular = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    CodigoSeguranca = table.Column<string>(nullable: true),
                    DataVencimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar", maxLength: 80, nullable: true),
                    Email = table.Column<string>(type: "varchar", maxLength: 80, nullable: true),
                    TelefoneAlternativo = table.Column<string>(type: "varchar", maxLength: 12, nullable: true),
                    TelefoneCelular = table.Column<string>(type: "varchar", maxLength: 12, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(type: "varchar", maxLength: 80, nullable: true),
                    DtNascimento = table.Column<DateTime>(type: "Date", nullable: true, defaultValueSql: "GetUtcDate()"),
                    NomeFantasia = table.Column<string>(type: "varchar", maxLength: 80, nullable: true),
                    Cnpj = table.Column<string>(type: "varchar", maxLength: 80, nullable: true),
                    InscMunicipal = table.Column<string>(type: "varchar", maxLength: 80, nullable: true),
                    InscEstadual = table.Column<string>(type: "varchar", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar", maxLength: 8, nullable: false),
                    QuantidadeMáxima = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    QuantidadeMinima = table.Column<int>(type: "int", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar", maxLength: 80, nullable: false),
                    Descricao = table.Column<string>(type: "varchar", maxLength: 80, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetUtcDate()"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<float>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_produto_categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar", maxLength: 8, nullable: true),
                    PessoaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cliente_pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_empresa_pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_endereco_pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vendedor_pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    DataPedido = table.Column<string>(nullable: true),
                    ValorTotal = table.Column<float>(nullable: false),
                    Situacao = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cartaofidelidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 80, nullable: true),
                    Descricao = table.Column<string>(maxLength: 80, nullable: true),
                    Tipo = table.Column<int>(maxLength: 1, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetUtcDate()"),
                    DataFim = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetUtcDate()"),
                    Pin = table.Column<bool>(type: "bit", nullable: false),
                    EmpresaId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Percentual = table.Column<string>(nullable: true),
                    Valor = table.Column<float>(nullable: true),
                    ValorMinimo = table.Column<float>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    PinCodigo = table.Column<string>(nullable: true),
                    Valido = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartaofidelidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cartaofidelidade_empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itensPedido",
                columns: table => new
                {
                    PedidoId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itensPedido", x => new { x.PedidoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_itensPedido_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itensPedido_produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPagamento = table.Column<DateTime>(nullable: false),
                    Pago = table.Column<bool>(nullable: false),
                    Valor = table.Column<float>(nullable: false),
                    PedidoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientecartaofidelidade",
                columns: table => new
                {
                    CartaoFidelidadeId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientecartaofidelidade", x => new { x.ClienteId, x.CartaoFidelidadeId });
                    table.ForeignKey(
                        name: "FK_clientecartaofidelidade_cartaofidelidade_CartaoFidelidadeId",
                        column: x => x.CartaoFidelidadeId,
                        principalTable: "cartaofidelidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clientecartaofidelidade_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pincartaofelicidade",
                columns: table => new
                {
                    PinId = table.Column<int>(nullable: false),
                    CartaoFidelidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pincartaofelicidade", x => new { x.PinId, x.CartaoFidelidadeId });
                    table.ForeignKey(
                        name: "FK_pincartaofelicidade_cartaofidelidade_CartaoFidelidadeId",
                        column: x => x.CartaoFidelidadeId,
                        principalTable: "cartaofidelidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pincartaofelicidade_pin_PinId",
                        column: x => x.PinId,
                        principalTable: "pin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "produtocartaofidelidade",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false),
                    CartaoFidelidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtocartaofidelidade", x => new { x.ProdutoId, x.CartaoFidelidadeId });
                    table.ForeignKey(
                        name: "FK_produtocartaofidelidade_cartaofidelidade_CartaoFidelidadeId",
                        column: x => x.CartaoFidelidadeId,
                        principalTable: "cartaofidelidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produtocartaofidelidade_produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartaofidelidade_EmpresaId",
                table: "cartaofidelidade",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_PessoaId",
                table: "cliente",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientecartaofidelidade_CartaoFidelidadeId",
                table: "clientecartaofidelidade",
                column: "CartaoFidelidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_empresa_PessoaId",
                table: "empresa",
                column: "PessoaId",
                unique: true,
                filter: "[PessoaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_endereco_PessoaId",
                table: "endereco",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_itensPedido_ProdutoId",
                table: "itensPedido",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_PedidoId",
                table: "Pagamentos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_pincartaofelicidade_CartaoFidelidadeId",
                table: "pincartaofelicidade",
                column: "CartaoFidelidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_produto_CategoriaId",
                table: "produto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_produtocartaofidelidade_CartaoFidelidadeId",
                table: "produtocartaofidelidade",
                column: "CartaoFidelidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_vendedor_PessoaId",
                table: "vendedor",
                column: "PessoaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "clientecartaofidelidade");

            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropTable(
                name: "itensPedido");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "pincartaofelicidade");

            migrationBuilder.DropTable(
                name: "produtocartaofidelidade");

            migrationBuilder.DropTable(
                name: "vendedor");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "pin");

            migrationBuilder.DropTable(
                name: "cartaofidelidade");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "empresa");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "pessoa");
        }
    }
}
