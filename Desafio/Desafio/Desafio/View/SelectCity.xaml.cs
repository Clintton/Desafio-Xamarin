using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Desafio.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectCity : ContentPage
	{
		public SelectCity ()
		{
			InitializeComponent ();

            CidadesListView.ItemsSource = Global.Cidades.Cidades;

        }

        private async void CidadesListView_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            CidadeDados cidadeDados = (CidadeDados)e.SelectedItem;
            await Navigation.PushAsync(new CityDetail(cidadeDados.id));
        }
    }
}