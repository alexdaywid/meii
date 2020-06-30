using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meii.Api.ViewModel
{
    public class ClientePessoaJuridicaViewModel
    {
        public int ClienteId { get; set; }
        public string Codigo { get; set; }
        public PessoaJuridicaViewModel Pessoa { get; set; }
    }
}
