using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class ClienteCartaoFidelidade
    {
        public int IdCartaoFedelidade { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public CartaoFidelidade CartaoFidelidade { get; set; }
    }
}
