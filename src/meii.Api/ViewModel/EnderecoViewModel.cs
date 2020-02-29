﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meii.Api.ViewModel
{
    public class EnderecoViewModel
    {
        public int EnderecoId { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Cep { get; set; }
    }
}
