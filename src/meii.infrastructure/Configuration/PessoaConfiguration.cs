using meii.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace meii.infrastructure.Configuration
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("pessoa");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                .HasMaxLength(80);

            builder.Property(p =>p.Email)
                .HasMaxLength(80);

            builder.Property(p => p.TelefoneAlternativo)
                .HasMaxLength(12);

            builder.Property(p => p.TelefoneCelular)
                .HasMaxLength(12);
        }
    }
}
