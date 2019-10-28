using Desafio.Models.DetalheCidade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using Desafio.Models;
using System.Net.Http.Headers;
using Desafio.Banco;

namespace Desafio.ViewModel
{
    public class ObterDetalheCidade : INotifyPropertyChanged
    {
        public CidadeDetalhe cidadeDetalhe { get; set; }
        public Database database = new Database();

        private string tempFormatado;
        private string tempMinFormatado;
        private string tempMaxFormatado;
        private Uri imagemUrl;
        private string descricaoFormatada;
        private bool favorita;

        public string TempFormatado
        {
            get { return tempFormatado; }
            set { tempFormatado = value; }
        }

        public string TempMinFormatado
        {
            get { return tempMinFormatado; }
            set { tempMinFormatado = value; }
        }

        public string TempMaxFormatado
        {
            get { return tempMaxFormatado; }
            set { tempMaxFormatado = value; }
        }

        public Uri ImagemUrl
        {
            get { return imagemUrl; }
            set { imagemUrl = value; }
        }

        public string DescricaoFormatada
        {
            get { return descricaoFormatada; }
            set { descricaoFormatada = value; }
        }

        public bool Favorita
        {
            get { return favorita; }
            set { favorita = value; }
        }

        public ObterDetalheCidade(int idCidade)
        {
            BuscarCidadeAsync(idCidade);
            VerificarFavorito(idCidade);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void BuscarCidadeAsync(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(string.Format(Global.MetodoApiUrl, id, Global.ChaveApi)).Result;
                string responseBody = await response.Content.ReadAsStringAsync();
                cidadeDetalhe = JsonConvert.DeserializeObject<CidadeDetalhe>(responseBody);

                tempFormatado = Convert.ToString(Math.Round(cidadeDetalhe.temperatura.temp, 0)) + " °C";
                tempMinFormatado = Convert.ToString(Math.Round(cidadeDetalhe.temperatura.temp_min, 0)) + " °C";
                tempMaxFormatado = Convert.ToString(Math.Round(cidadeDetalhe.temperatura.temp_max, 0)) + " °C";

                imagemUrl = new Uri(string.Format(Global.IconeUrl, cidadeDetalhe.weather[0].icon));
                descricaoFormatada = char.ToUpper(cidadeDetalhe.weather[0].description[0]) + cidadeDetalhe.weather[0].description.Substring(1);
            }

        }

        public void VerificarFavorito(int id)
        {
            Favorita cidadeDados = database.ObterCidadePorId(id);

            if (cidadeDados == null)
            {
                favorita = false;
            }
            else
            {
                favorita = true;
            }
        }

        public void SalvarFavorita()
        {
            Favorita favorita = new Favorita();
            favorita.id = cidadeDetalhe.id;
            favorita.nome = cidadeDetalhe.name;

            database.SalvarFavorito(favorita);
        }

        public void RemoverFavorita()
        {
            Favorita favorita = new Favorita();
            favorita.id = cidadeDetalhe.id;
            favorita.nome = cidadeDetalhe.name;
            
            database.RemoverFavoritos(favorita);
        }
    }
}
