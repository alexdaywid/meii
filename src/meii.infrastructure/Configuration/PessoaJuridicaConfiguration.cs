using meii.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace meii.infrastructure.Configuration
{
    public class PessoaJuridicaConfiguration : IEntityTypeConfiguration<PessoaJuridica>
    {
        public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
        {
            
            builder.Property(pj => pj.Cnpj)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(pj => pj.NomeFantasia)
               .HasMaxLength(80)
               .IsRequired();

            builder.Property(pj => pj.InscEstadual)
               .HasMaxLength(80);

            builder.Property(pj => pj.InscMunicipal)
               .HasMaxLength(80);     
        }
    }
}
