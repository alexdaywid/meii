using meii.applicationCore.Services;
using meii.Business.Entities;
using meii.Business.Entities.Validation;
using meii.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace meii.Business.Services
{
    public class EmpresaService : BaseServices, IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        public EmpresaService(IEmpresaRepository empresaRepository,
            INotificador notificador) : base(notificador)
        {
            _empresaRepository = empresaRepository;
        }
        public Task Atualizar(Empresa empresa)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _empresaRepository?.Dispose();
        }

        public async Task Excluir(Empresa empresa)
        {
            throw new NotImplementedException();
        }

        public async Task Salvar(Empresa empresa)
        {
            if (!ExecutarValidacao(new EmpresaValidation(), empresa))
                return;

            await _empresaRepository.Add(empresa);
        }
    }
}
