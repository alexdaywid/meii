using meii.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace meii.infrastructure.Configuration
{
    public class ItensPedidoConfiguration : IEntityTypeConfiguration<ItensPedido>
    {
        public void Configure(EntityTypeBuilder<ItensPedido> builder)
        {
            builder.ToTable("itensPedido");
            builder.HasKey(i => new { i.PedidoId, i.ProdutoId });

            builder.HasOne<Pedido>(i => i.Pedido)
                .WithMany(p => p.ItensPedidos)
                .HasForeignKey(i => i.PedidoId)
                .IsRequired();

            builder.HasOne<Produto>(i => i.Produto)
                .WithMany(p => p.ItensPedidos)
                .HasForeignKey(i => i.ProdutoId);

            builder.Property(i => i.Valor).HasColumnType("money").IsRequired();

            builder.Property(i => i.Quantidade).HasColumnType("int").IsRequired();


        }
    }
}
