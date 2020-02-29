using meii.Business.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace meii.infrastrutucture.Context
{
    public class MEContext : DbContext
    {
        public MEContext(DbContextOptions<MEContext> options) : base(options){ }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridicas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empreendedor> Empreendedores { get; set; }
    }
}
