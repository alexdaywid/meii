using System.Collections.Generic;
using System.Threading.Tasks;
using meii.Business.Entities;
using meii.Business.Interfaces;
using meii.Business.Repository;
using meii.infrastrutucture.Context;
using Microsoft.EntityFrameworkCore;

namespace meii.infrastrutucture.Repository
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MEContext context) : base(context)
        {

        }

        public async override Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.AsNoTracking()
                           .Include(p => p.Pessoa)
                                .ThenInclude(e => e.Endereco).ToListAsync();
        }

        public async override Task<Cliente> GetId(int id)
        {
            return await _context.Clientes
                .AsNoTracking()
                .Include(p => p.Pessoa)
                    .ThenInclude(e => e.Endereco)
                .FirstOrDefaultAsync(c => c.ClienteId == id);
        }

    }
}
