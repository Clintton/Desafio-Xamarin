using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Models
{
    public class CidadeDados
    {
        public int id { get; set; }
        public Coordenadas coord { get; set; }
        public string country { get; set; }
        public string name { get; set; }
        public int zoom { get; set; }
    }
}
