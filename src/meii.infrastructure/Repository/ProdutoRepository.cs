using meii.Business.Entities;
using meii.Business.Interfaces;
using meii.infrastrutucture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace meii.infrastructure.Repository
{
    public class ProdutoRepository : EFRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MEContext context) : base(context)
        {
        }

        public async Task<Produto> BuscarProdutoCategoriaPorId(int produtoId)
        {
            return await _context.Produtos.AsNoTracking()
                .Include(c => c.Categoria).FirstOrDefaultAsync(p => p.Id == produtoId);
        }

        public Task<Produto> BuscarProdutoItensProduto(int produtoId)
        {
            return _context.Produtos.AsNoTracking()
                .Include(i => i.ItensPedidos).FirstOrDefaultAsync(p => p.Id == produtoId);
        }
    }
}
