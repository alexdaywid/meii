using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class Vendedor
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }


    }
}
