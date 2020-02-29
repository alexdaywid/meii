using meii.Business.Entities;
using meii.Business.Interfaces;
using meii.infrastrutucture.Context;
using meii.infrastrutucture.Repository;

namespace meii.Business.Repository
{
    public class EmpreendedorRepository : EFRepository<Empreendedor>, IEmpreendedorRepository
    {
        public EmpreendedorRepository(MEContext context) : base(context)
        {
        }
    }
}
