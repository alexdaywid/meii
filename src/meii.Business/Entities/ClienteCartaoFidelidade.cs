using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class ClienteCartaoFidelidade
    {
        public int CartaoFedelidadeId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public CartaoFidelidade CartaoFidelidade { get; set; }
    }
}
