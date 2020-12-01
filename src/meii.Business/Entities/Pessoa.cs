using meii.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Entities
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string TelefoneAlternativo { get; set; }
        public string TelefoneCelular { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Endereco> Endereco { get; set; }
    }
}
