﻿using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class PessoaFisica : Pessoa
    {
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DtNascimento { get; set; }
    }
}
