using meii.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace meii.Business.Interfaces
{
    public interface ICategoriaService: IDisposable
    {
        Task Salvar(Categoria categoria);
        Task Atualizar(Categoria categoria);
        Task Excluir(Categoria categoria);
    }
}
