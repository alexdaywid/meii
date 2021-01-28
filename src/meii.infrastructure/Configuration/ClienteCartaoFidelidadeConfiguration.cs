using System;
using System.Collections.Generic;
using System.Text;
using meii.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace meii.infrastructure.Configuration
{
    public class ClienteCartaoFidelidadeConfiguration : IEntityTypeConfiguration<ClienteCartaoFidelidade>
    {
        public void Configure(EntityTypeBuilder<ClienteCartaoFidelidade> builder)
        {
            builder.ToTable("clientecartaofidelidade")
            .HasKey(cc => new { cc.ClienteId, cc.CartaoFidelidadeId});

            builder.HasOne(cc => cc.CartaoFidelidade)
            .WithMany(cc => cc.ClienteCartaoFidelidades)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cc => cc.Cliente)
            .WithMany(cc => cc.ClienteCartaoFidelidades)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
