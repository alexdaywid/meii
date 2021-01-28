using System;
using System.Collections.Generic;
using System.Text;
using meii.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace meii.infrastructure.Configuration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(80);

            builder.Property(p => p.DataCadastro)
                .HasColumnType("Date")
                .HasDefaultValueSql("GetUtcDate()");

            builder.Property(p => p.Quantidade)
                .HasColumnType("int");

            builder.HasOne(p => p.Categoria)
                .WithMany(p => p.Produto)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}
