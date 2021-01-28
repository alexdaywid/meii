using meii.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace meii.infrastructure.Configuration
{
    public class VendedorConfiguration : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.ToTable("vendedor")
                .HasKey(e => e.Id);
            
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.PessoaId);

            //One-to-One Relationships
            builder.HasOne<Pessoa>(e => e.Pessoa)
                .WithOne(p => p.Vendedor)
                .HasForeignKey<Vendedor>(e => e.PessoaId);


            
        }
    }
}
