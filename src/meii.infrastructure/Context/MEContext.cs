using meii.Business.Entities;
using meii.infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace meii.infrastrutucture.Context
{
    public class MEContext : DbContext
    {
        public MEContext(DbContextOptions<MEContext> options) : base(options) { }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridicas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Cartoes> Cartoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pin> Pin { get; set; }
        public DbSet<PinCartaoFidelidade> PinCartaoFidelidades { get; set; }
        public DbSet<CartaoFidelidade> CartaoFidelidades { get; set; }
        public DbSet<ClienteCartaoFidelidade> ClienteCartaoFidelidades { get; set; }
        public DbSet<ProdutoCartaoFidelidade> ProdutoCartaoFidelidades { get; set; }
        public DbSet<Indicacao> Indicacaos { get; set; }
        public DbSet<ItensPedido> ItensPedidos { get; set; }
        public DbSet<Desconto> Descontos { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new CartaoFidelidadeConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteCartaoFidelidadeConfiguration());       
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new ItensPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new PessoaConfiguration());
            modelBuilder.ApplyConfiguration(new PessoaFisicaConfiguration());
            modelBuilder.ApplyConfiguration(new PessoaJuridicaConfiguration());
            modelBuilder.ApplyConfiguration(new PinConfiguration());
            modelBuilder.ApplyConfiguration(new PinCartaoFidelidadeConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoCartaoFidelidadeConfiguration());
            modelBuilder.ApplyConfiguration(new VendedorConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());

        }
    }
}
