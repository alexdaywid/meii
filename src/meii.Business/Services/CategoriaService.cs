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
    public class CategoriaService : BaseServices, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(
            ICategoriaRepository categoriaRepository,
            INotificador notificador) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task Atualizar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria))
                return;
         
            await _categoriaRepository.Update(categoria);
        }

        public async Task Excluir(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria))
                return;

            if (_categoriaRepository.BuscarCategoriaProduto(categoria.Id).Result.Produto.Any())
                Notificar("Não poderá excluir essa categoria pois esta associada a um produto");
            
            await _categoriaRepository.Remove(categoria);           
        }

        public async Task Salvar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria))
                return;

            await _categoriaRepository.Add(categoria);
        }

        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }
    }
}
