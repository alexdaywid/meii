using meii.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace meii.Business.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task<Produto> Salvar(Produto produto);
        Task Atualizar(Produto produto);
        Task Excluir(Produto produto);
    }
}
