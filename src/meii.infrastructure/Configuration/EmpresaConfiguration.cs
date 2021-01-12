using meii.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace meii.infrastructure.Configuration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa")
                .HasKey(e => e.Id);

            builder.Property(e => e.PessoaId);

            //One-to-One Relationships
            builder.HasOne<Pessoa>(e => e.Pessoa)
                .WithOne(p => p.Empresa)
                .HasForeignKey<Empresa>(e => e.PessoaId);

            
        }
    }
}
