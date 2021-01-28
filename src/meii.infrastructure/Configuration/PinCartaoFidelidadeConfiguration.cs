using System;
using System.Collections.Generic;
using System.Text;
using meii.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace meii.infrastructure.Configuration
{
    public class PinCartaoFidelidadeConfiguration : IEntityTypeConfiguration<PinCartaoFidelidade>
    {
        public void Configure(EntityTypeBuilder<PinCartaoFidelidade> builder)
        {
            builder.ToTable("pincartaofelicidade");
            builder.HasKey(pc => new { pc.PinId, pc.CartaoFidelidadeId });

            builder.HasOne(pc => pc.CartaoFidelidade)
            .WithMany(pc => pc.PinCartaoFidelidades)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pc => pc.Pin)
            .WithMany(pc => pc.PinCartaoFidelidades)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
