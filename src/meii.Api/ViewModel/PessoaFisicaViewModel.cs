using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace meii.Api.ViewModel
{
    public class PessoaFisicaViewModel : PessoaViewModel
    {
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo Rg é obrigatório.")]
        public string Rg { get; set; }

        public DateTime DtNascimento { get; set; }
    }
}
