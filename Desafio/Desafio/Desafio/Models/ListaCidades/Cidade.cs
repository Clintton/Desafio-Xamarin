using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Models
{
    public class Cidade
    {
        [JsonProperty("data")]
        public List<CidadeDados> Cidades { get; set; }
    }
}
