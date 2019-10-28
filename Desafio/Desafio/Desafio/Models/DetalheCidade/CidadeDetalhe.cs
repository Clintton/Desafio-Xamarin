using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Desafio.Models.DetalheCidade
{
    public class CidadeDetalhe
    {

        public int id { get; set; }
        public string name { get; set; }
        [JsonProperty("main")]
        public Temperatura temperatura { get; set; }
        public List<Weather> weather { get; set; }
    }
}
