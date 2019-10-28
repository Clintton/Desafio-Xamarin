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
	public partial class CityDetail : ContentPage
	{
        public ObterDetalheCidade obterDetalheCidade;

        public CityDetail (int idCidade)
		{
			InitializeComponent ();
            obterDetalheCidade = new ObterDetalheCidade(idCidade);

            BindingContext = obterDetalheCidade;

            toggle.Toggled += Switch_Toggled;
        }

        private void Toggle_Toggled(object sender, ToggledEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (!obterDetalheCidade.Favorita)
            {
                obterDetalheCidade.RemoverFavorita();
                obterDetalheCidade.Favorita = !obterDetalheCidade.Favorita;
            }
            else
            {
                obterDetalheCidade.SalvarFavorita();
                obterDetalheCidade.Favorita = !obterDetalheCidade.Favorita;
            }
        }
    }
}