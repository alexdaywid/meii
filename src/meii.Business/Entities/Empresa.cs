using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public ICollection<ClienteCartaoFidelidade> ClienteCartaoFidelidades { get; set; }
    }
}
