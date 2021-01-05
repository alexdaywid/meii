using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class ProdutoCartaoFidelidade
    {
        public int ProdutoId { get; set; }
        public int CartaoFidelidadeId { get; set; }
        public Produto Produto { get; set; }
        public CartaoFidelidade CartaoFidelidade { get; set; }
    }
}
