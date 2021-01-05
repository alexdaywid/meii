using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class PinCartaoFidelidade
    {
        public int PinId { get; set; }
        public int CartaoFidelidadeId { get; set; }
        public Pin Pin { get; set; }
        public CartaoFidelidade CartaoFidelidade { get; set; }

    }
}
