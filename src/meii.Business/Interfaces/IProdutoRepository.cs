using meii.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace meii.Business.Interfaces
{
    public interface IProdutoRepository: IRepository<Produto>
    {
        Task<Produto> BuscarProdutoCategoriaPorId(int produtoId);
        Task<Produto> BuscarProdutoItensProduto(int produtoId);
    }
}
