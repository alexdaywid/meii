using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class Pagamento
    {
        public int Id { get; set; }
        public DateTime DataPagamento { get; set; }
        public bool Pago { get; set; }
        public float Valor { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}
