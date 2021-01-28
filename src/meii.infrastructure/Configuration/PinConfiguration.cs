using System;
using System.Collections.Generic;
using System.Text;
using meii.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace meii.infrastructure.Configuration
{
    public class PinConfiguration : IEntityTypeConfiguration<Pin>
    {
        public void Configure(EntityTypeBuilder<Pin> builder)
        {
            builder.ToTable("pin");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder.Property(p => p.Codigo)
                .HasColumnType("varchar")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(p => p.QuantidadeMinima)
                .HasColumnType("int")
                .HasMaxLength(8);

            builder.Property(p => p.QuantidadeMáxima)
                .HasColumnType("int")
                .HasMaxLength(8);

        }
    }
}
