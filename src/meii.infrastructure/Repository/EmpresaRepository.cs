using meii.Business.Entities;
using meii.Business.Interfaces;
using meii.infrastrutucture.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace meii.infrastructure.Repository
{
    public class EmpresaRepository : EFRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(MEContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Empresa>> GetAll()
        {
            return await _context.Empresas.AsNoTracking()
                           .Include(p => p.Pessoa)
                                .ThenInclude(e => e.Endereco).ToListAsync();
        }
    }
}
