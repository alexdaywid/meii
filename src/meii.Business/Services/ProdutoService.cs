using meii.applicationCore.Services;
using meii.Business.Entities;
using meii.Business.Entities.Notificacoes;
using meii.Business.Entities.Validation;
using meii.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meii.Business.Services
{
    public class ProdutoService : BaseServices, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(
            IProdutoRepository produtoRepository, 
            INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
                return;

            await _produtoRepository.Update(produto);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

        public async Task Excluir(Produto produto)
        {
            if (_produtoRepository.BuscarProdutoItensProduto(produto.Id).Result.ItensPedidos.Any())
            {
                Notificar("Produto não pode ser excluído pois está associado a um pedido");
                return;
            } 

            await _produtoRepository.Remove(produto);
        }

        public async Task<Produto> Salvar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
                return null;

            await _produtoRepository.Add(produto);

            return produto;
        }
    }
}
