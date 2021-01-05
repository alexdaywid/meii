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
            throw new NotImplementedException();
        }
    }
}
