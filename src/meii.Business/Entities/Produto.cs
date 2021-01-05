using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Quantidade { get; set; }
        public float  Valor { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public ICollection<ItensPedido> ItensPedidos { get; set; }
        public ICollection<ProdutoCartaoFidelidade> ProdutoCartaoFidelidade { get; set; }

    }
}
