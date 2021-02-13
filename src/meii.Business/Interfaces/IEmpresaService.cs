using meii.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace meii.Business.Interfaces
{
    public interface IEmpresaService : IDisposable
    {
        Task Salvar(Empresa empresa);
        Task Atualizar(Empresa empresa);
        Task Excluir(Empresa empresa);
    }
}
