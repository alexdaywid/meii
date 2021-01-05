using meii.Business.Entities;
using meii.Business.Interfaces;
using meii.infrastrutucture.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace meii.infrastructure.Repository
{
    public class CartaoFidelidadeRepository : EFRepository<CartaoFidelidade>, ICartaoFidelidadeRepository
    {
        public CartaoFidelidadeRepository(MEContext context) : base(context)
        {
        }
    }
}
