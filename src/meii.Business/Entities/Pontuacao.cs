using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public class Pontuacao : CartaoFidelidade
    {
        public int Quantidade { get; set; }
        public int Round { get; set; }
    }
}
