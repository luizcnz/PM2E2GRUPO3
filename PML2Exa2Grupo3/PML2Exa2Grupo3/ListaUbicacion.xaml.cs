using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PML2Exa2Grupo3.viewmodel;
using PML2Exa2Grupo3.Config;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PML2Exa2Grupo3.Models;
using System.Windows.Input;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.ObjectModel;

namespace PML2Exa2Grupo3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    

    public partial class ListaUbicacion : ContentPage
    {
        public ObservableCollection<Sitios> SitiosList { get; set; }
        private Sitios seleccinarId;
        private object cliente;

        public ListaUbicacion()
        {

            InitializeComponent();
        

       
        }        

        protected async override void OnAppearing()
        {
            base.OnAppearing();
       
        }

        private async void btnSeeUbications_Clicked(object sender, EventArgs e)
        {
            var sitio = new
            {
                Latitud = seleccinarId.Latitud,
                Longitud = seleccinarId.Longitud
            };

            //await DisplayAlert("Datos a Enviar> " + seleccinarId.Id + " " + seleccinarId.DescripcionCorta, " Ubicacion Larga> " + seleccinarId.DescripcionLarga + " Coordenadas >> " + seleccinarId.Latitud + " " + seleccinarId.Longitud, "OK");

            var Page = new ListaFourSquare();
            Page.BindingContext = sitio;
            await Navigation.PushAsync(Page);
            seleccinarId = null;

        }

        

      
        private async void btnDeleteUbications_Clicked_1(object sender, EventArgs e)
        {
            HttpClient cliente = new HttpClient();
            if (seleccinarId != null)
            {

                Uri uri = new Uri(string.Format(URL.getUrl("/delete/" + seleccinarId.Id)));
                HttpResponseMessage response = await cliente.DeleteAsync(uri);
                var result = await cliente.DeleteAsync(uri);

                if (result.IsSuccessStatusCode)
                {

                    //SitiosList.Remove(seleccinarId.Id);
                    Debug.WriteLine("successfully deleted.");
                }
            }
            else
            {
                await DisplayAlert("Alerta", "Para poder Eliminar Seleccione un campo", "Entendido!");
            }
        }

        private void ListMisUbicaciones_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            seleccinarId = e.SelectedItem as Sitios;
        }
    }

    }