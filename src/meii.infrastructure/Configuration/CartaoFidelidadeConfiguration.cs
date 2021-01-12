using meii.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace meii.infrastructure.Configuration
{
    public class CartaoFidelidadeConfiguration : IEntityTypeConfiguration<CartaoFidelidade>
    {
        public void Configure(EntityTypeBuilder<CartaoFidelidade> builder)
        {
            builder.ToTable("cartaofidelidade");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasMaxLength(80);


            builder.Property(c => c.Descricao)
                .HasMaxLength(80);

            builder.Property(c => c.Tipo)
                .HasMaxLength(1);

            builder.Property(c => c.Ativo)
                .IsRequired();

            builder.Property(c => c.DataCadastro)
                .HasColumnType("Date")
                .HasDefaultValueSql("GetUtcDate()");

            builder.Property(c => c.DataFim)
                .HasColumnType("Date")
                .HasDefaultValueSql("GetUtcDate()");

            builder.Property(c => c.Pin);






        }
    }
}
