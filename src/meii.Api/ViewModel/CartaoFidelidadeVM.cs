using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meii.Api.ViewModel
{
    public class CartaoFidelidadeVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Tipo { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataFim { get; set; }
        public bool Pin { get; set; }
        public int EmpresaId { get; set; }
        //public Empresa Empresa { get; set; }
        //public ICollection<ProdutoCartaoFidelidade> ProdutoCartaoFidelidade { get; set; }
        //public ICollection<PinCartaoFidelidade> PinCartaoFidelidades { get; set; }
        //public ICollection<ClienteCartaoFidelidade> ClienteCartaoFidelidades { get; set; }
    }
}
