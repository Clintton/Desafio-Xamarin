using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Desafio.Banco;
using System.IO;
[assembly:Dependency(typeof(Desafio.Droid.Banco.Caminho))]
namespace Desafio.Droid.Banco
{
    class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            string caminhoPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoBanco = Path.Combine(caminhoPasta, NomeArquivoBanco);

            return caminhoBanco;
        }
    }
}