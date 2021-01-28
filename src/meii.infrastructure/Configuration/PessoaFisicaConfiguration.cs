using meii.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace meii.infrastructure.Configuration
{
    public class PessoaFisicaConfiguration : IEntityTypeConfiguration<PessoaFisica>
    {
        public void Configure(EntityTypeBuilder<PessoaFisica> builder)
        {
            
            builder.Property(pf => pf.Cpf)
                .HasColumnType("varchar")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(pf => pf.DtNascimento)
                .HasColumnType("Date")
                .HasDefaultValueSql("GetUtcDate()");
        }
    }
}
