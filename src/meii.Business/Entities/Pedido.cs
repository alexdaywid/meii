using meii.Business.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string DataPedido { get; set; }
        public float ValorTotal { get; set; }
        public Situacao Situacao { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<ItensPedido> ItensPedidos { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }
    }
}
