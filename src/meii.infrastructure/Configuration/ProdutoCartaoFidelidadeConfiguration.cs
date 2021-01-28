using System;
using System.Collections.Generic;
using System.Text;
using meii.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace meii.infrastructure.Configuration
{
    public class ProdutoCartaoFidelidadeConfiguration : IEntityTypeConfiguration<ProdutoCartaoFidelidade>
    {
        public void Configure(EntityTypeBuilder<ProdutoCartaoFidelidade> builder)
        {
            builder.ToTable("produtocartaofidelidade")
                   .HasKey(pc => new { pc.ProdutoId, pc.CartaoFidelidadeId });

            builder.HasOne(pc => pc.CartaoFidelidade)
            .WithMany(pc => pc.ProdutoCartaoFidelidade)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pc => pc.Produto)
            .WithMany(pc => pc.ProdutoCartaoFidelidade)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
