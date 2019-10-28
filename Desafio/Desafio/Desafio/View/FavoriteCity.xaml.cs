using Desafio.Models;
using Desafio.ViewModel;
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
	public partial class FavoriteCity : ContentPage
	{
        public ObterCidadesFavoritas obterCidadesFavoritas;
        public FavoriteCity ()
		{
			InitializeComponent ();

            obterCidadesFavoritas = new ObterCidadesFavoritas();

            BindingContext = obterCidadesFavoritas;
            CidadesListView.ItemsSource = obterCidadesFavoritas.Favoritas;
        }

        private async void ToolbarItem_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectCity());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            obterCidadesFavoritas.ObterListaCidades();
            List<InfoFavorita> list = await obterCidadesFavoritas.ObterInfoFavoritasAsync();
            CidadesListView.ItemsSource = list;
        }

        private async void CidadesListView_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            InfoFavorita infoFavorita = (InfoFavorita)e.SelectedItem;
            await Navigation.PushAsync(new CityDetail(infoFavorita.Id));
        }

        private void CidadesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}