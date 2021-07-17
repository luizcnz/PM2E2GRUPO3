using Plugin.Media.Abstractions;
using PML2Exa2Grupo3.Config;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace PML2Exa2Grupo3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ListaFourSquare : ContentPage
    {
        private Metodos seleccionarItem;
        private String ItemNombre;
        private double ItemLactitud;
        private double ItemLongitud;
        public double Longitud { get; set; }
        public double Latitud { get; set; }

        public ListaFourSquare()
        {
            InitializeComponent();
            
        }


        protected async override void OnAppearing()
        {
            Longitud = Convert.ToDouble(txtLongitud.Text);
            Latitud = Convert.ToDouble(txtLatitud.Text);
            ListFourSquare.ItemsSource = await Metodos.getSites(Latitud, Longitud, 150);

        }

        private async void btnHowToGet_Clicked(object sender, EventArgs e)
        {
            var newubication = new Xamarin.Essentials.Location(ItemLactitud, ItemLongitud);
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };

            await Xamarin.Essentials.Map.OpenAsync(newubication, options);
            newubication = null;

        }

        private void ListFourSquare_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var seleccionarItem = e.SelectedItem as Metodos.Venue;
            ItemNombre = seleccionarItem.name;
            ItemLactitud = seleccionarItem.location.lat;
            ItemLongitud = seleccionarItem.location.lng;
        }
    }
}