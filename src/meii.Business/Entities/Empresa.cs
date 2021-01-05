using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        public Pessoa Pessoa { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public ICollection<ClienteCartaoFidelidade> ClienteCartaoFidelidades { get; set; }
    }
}
