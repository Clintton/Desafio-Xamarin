using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Models
{
    [SQLite.Table("Favorita")]
    public class Favorita
    {
        [SQLite.PrimaryKey]
        public int id { get; set; }
        public string nome { get; set; }

    }
}
