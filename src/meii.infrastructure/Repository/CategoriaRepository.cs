using meii.Business.Entities;
using meii.Business.Interfaces;
using meii.infrastrutucture.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meii.infrastructure.Repository
{
    public class CategoriaRepository : EFRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(MEContext context) : base(context)
        {
        }

        public async Task<Categoria> BuscarCategoriaProduto(int categoriaId)
        {
            var query = await _context.Categorias.AsNoTracking()
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(c => c.Id == categoriaId);

            return query;
        }
    }
}
