using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class PinCartaoFidelidade
    {
        public int IdPin { get; set; }
        public int IdCartaoFidelidade { get; set; }
        public Pin Pin { get; set; }
        public CartaoFidelidade CartaoFidelidade { get; set; }

    }
}
