using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class Indicacao : CartaoFidelidade
    {
        public string Link { get; set; }
        public string PinCodigo { get; set; }
        public bool Valido { get; set; }
    }
}
