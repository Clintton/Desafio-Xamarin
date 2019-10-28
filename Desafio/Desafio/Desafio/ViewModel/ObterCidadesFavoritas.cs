using Desafio.Banco;
using Desafio.Models;
using Desafio.Models.DetalheCidade;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Desafio.ViewModel
{
    public class ObterCidadesFavoritas : INotifyPropertyChanged
    {
        public Database database = new Database();


        private List<Favorita> favoritas;
        private CidadeDetalhe cidadeDetalhe;
        private string descricaoFormatada;
        private string tempFormatado;



        public List<Favorita> Favoritas { get => favoritas; set => favoritas = value; }
        public CidadeDetalhe CidadeDetalhe { get => cidadeDetalhe; set => cidadeDetalhe = value; }
        public string DescricaoFormatada { get => descricaoFormatada; set => descricaoFormatada = value; }
        public string TempFormatado { get => tempFormatado; set => tempFormatado = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObterCidadesFavoritas()
        {
            ObterListaCidades();
        }
        public List<Favorita> ObterListaCidades()
        {
            return database.ConsultarDados();
        }

        public async System.Threading.Tasks.Task<List<InfoFavorita>> ObterInfoFavoritasAsync()
        {
            List<InfoFavorita> infoFavoritas = new List<InfoFavorita>();

            foreach (var item in ObterListaCidades())
            {
                InfoFavorita infoFavorita = new InfoFavorita();

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync(string.Format(Global.MetodoApiUrl, item.id, Global.ChaveApi)).Result;
                    string responseBody = await response.Content.ReadAsStringAsync();
                    CidadeDetalhe = JsonConvert.DeserializeObject<CidadeDetalhe>(responseBody);

                    infoFavorita.Temperatura = Convert.ToString(Math.Round(CidadeDetalhe.temperatura.temp, 0)) + " °C";
                    infoFavorita.Clima = char.ToUpper(CidadeDetalhe.weather[0].description[0]) + CidadeDetalhe.weather[0].description.Substring(1);
                    infoFavorita.Nome = item.nome;
                    infoFavorita.Id = item.id;
                    infoFavoritas.Add(infoFavorita);
                }
            }

            return infoFavoritas;
        }
    }
}
