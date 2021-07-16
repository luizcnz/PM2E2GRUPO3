using PML2Exa2Grupo3.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PML2Exa2Grupo3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaFourSquare : ContentPage
    {
        public ListaFourSquare()
        {
            InitializeComponent();
        }
        private async void btnConsume_Clicked(object sender, EventArgs e)
        {
            ListFourSquare.ItemsSource = await Metodos.getSites(14.09738, -87.2053992);
        }
    }
}