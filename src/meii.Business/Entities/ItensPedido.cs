using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class ItensPedido
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public float Valor { get; set; }

    }
}
