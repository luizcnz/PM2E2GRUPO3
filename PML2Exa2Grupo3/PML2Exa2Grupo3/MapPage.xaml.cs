using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace PML2Exa2Grupo3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        Double lactitud;
        Double Longitud;

        public MapPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();


            Longitud = Convert.ToDouble(txtMapaLongitud.Text);
            lactitud = Convert.ToDouble(txtMapaLactitud.Text);

            Pin ubicacion = new Pin();
            {
                ubicacion.Label = txtMapaNombre.Text;
                ubicacion.Type = PinType.Place;
                ubicacion.Position = new Position(lactitud, Longitud);

            }
            mpMapa.Pins.Add(ubicacion);


            var localizacion = await Geolocation.GetLastKnownLocationAsync();

            if (localizacion == null)
            {

                localizacion = await Geolocation.GetLocationAsync();
            }
            mpMapa.MoveToRegion(MapSpan.FromCenterAndRadius(ubicacion.Position, Distance.FromKilometers(1)));
        }

        private async void btnDriving_Clicked(object sender, EventArgs e)
        {
            var location = new Location(lactitud, Longitud);
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };

            await Xamarin.Essentials.Map.OpenAsync(location, options);
        }
    }

}