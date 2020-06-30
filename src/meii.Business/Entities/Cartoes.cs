using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class Cartoes
    {
        public int Id { get; set; }
        public string Titular { get; set; }
        public string Numero { get; set; }
        public string CodigoSeguranca {get;set;}
        public DateTime DataVencimento { get; set; }
    }
}
