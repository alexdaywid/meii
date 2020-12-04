using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public abstract class CartaoFidelidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Tipo { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataFim { get; set; }
        public bool GerarPin { get; set; }
        public ICollection<ProdutoCartaoFidelidade> ProdutoCartaoFidelidade { get; set; }
        public ICollection<PinCartaoFidelidade> PinCartaoFidelidades { get; set; }
        public ICollection<ClienteCartaoFidelidade> ClienteCartaoFidelidades { get; set; }

    }
}
