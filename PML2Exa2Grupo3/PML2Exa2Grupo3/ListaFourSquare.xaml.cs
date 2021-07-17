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
<<<<<<< HEAD
        private Metodos seleccionarItem;
        private String ItemNombre;
        private double ItemLactitud;
        private double ItemLongitud;

        public ListaFourSquare()
        {
            InitializeComponent();  

        }


        protected async override void OnAppearing()
        {
            ListFourSquare.ItemsSource = await Metodos.getSites(13.301279153699598, -87.1824633751975, 150);

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

=======
        public double Longitud{get;set;}
        public double Latitdud { get; set; }
        public ListaFourSquare(double latitud, double longitud)
        {
            InitializeComponent();
            Longitud = longitud;
            Latitdud = latitud;
        }
        
       
        private async void btnConsume_Clicked(object sender, EventArgs e)
        {
            ListFourSquare.ItemsSource = await Metodos.getSites(Latitdud, Longitud);
>>>>>>> 50b29916deff5585fb26d8b5fd5dc17d466e4d70
        }
    }
}