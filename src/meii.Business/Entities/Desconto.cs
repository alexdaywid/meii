using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class Desconto : CartaoFidelidade
    {
        public string Percentual { get; set; }
        public float Valor { get; set; }
        public float ValorMinimo { get; set; }

    }
}
