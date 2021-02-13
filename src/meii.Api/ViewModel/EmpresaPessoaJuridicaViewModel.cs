using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meii.Api.ViewModel
{
    public class EmpresaPessoaJuridicaViewModel
    {
        public int Id { get; set; }
        public PessoaJuridicaViewModel Pessoa { get; set; }
    }
}
