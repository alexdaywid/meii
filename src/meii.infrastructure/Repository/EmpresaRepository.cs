using meii.Business.Entities;
using meii.Business.Interfaces;
using meii.infrastrutucture.Context;

namespace meii.infrastructure.Repository
{
    public class EmpresaRepository : EFRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(MEContext context) : base(context)
        {
        }
    }
}
