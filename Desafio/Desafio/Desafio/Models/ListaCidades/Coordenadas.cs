using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Models
{
    [JsonObject]
    public class Coordenadas
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }
}
