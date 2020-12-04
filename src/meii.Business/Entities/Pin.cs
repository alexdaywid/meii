using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class Pin
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int QuantidadeMáxima { get; set; }
        public int QuantidadeMinima { get; set; }
        public ICollection<PinCartaoFidelidade> PinCartaoFidelidades { get; set; }
    }
}
