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
    public class ClienteServices : BaseServices , IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteServices(INotificador notificador, IClienteRepository clienteRepository) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Add(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente))
                return;

            await _clienteRepository.Add(cliente);
           
        }

        public Task<Cliente> GetId(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
