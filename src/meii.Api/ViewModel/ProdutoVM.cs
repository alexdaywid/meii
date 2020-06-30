using meii.Business.Generico;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace meii.Api.ViewModel
{
    public class ProdutoVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DataCadastro { get; set; }
        public int Quantidade { get; set; }
        public float Valor { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaVM Categoria { get; set; }

        [NotMapped]
        public string Teste { get; set; }
    }

}
