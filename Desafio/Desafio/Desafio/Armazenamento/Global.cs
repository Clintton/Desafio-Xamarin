using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Models
{
    //Responsável por salvar na memória variavéis globais
    public static class Global
    {
        public static Cidade Cidades { get; set; }
        public static string ChaveApi = "2bac87e0cb16557bff7d4ebcbaa89d2f";
        public static string MetodoApiUrl = "http://api.openweathermap.org/data/2.5/weather?id={0}&appid={1}&lang=pt&units=metric";
        public static string IconeUrl = "http://openweathermap.org/img/wn/{0}@2x.png";
    }
}
