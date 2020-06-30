using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto> Produto { get; set; }
    }
}
