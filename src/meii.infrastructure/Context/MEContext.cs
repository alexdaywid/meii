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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new ItensPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

        }
    }
}
