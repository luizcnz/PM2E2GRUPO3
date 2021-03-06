using Newtonsoft.Json;
using Plugin.Geolocator;
using Plugin.Media;
using PML2Exa2Grupo3.Config;
using PML2Exa2Grupo3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using PML2Exa2Grupo3.viewmodel;
using Xamarin.Forms;
using Plugin.Connectivity;

namespace PML2Exa2Grupo3
{
    public partial class MainPage : ContentPage
    {

        //Se crea de manera global de manera que permite acceder a el despues de haber tomado la foto
        byte[] arrayImagen = null;
        public MainPage()
        {
            InitializeComponent();

            var localizacion = CrossGeolocator.Current;
            if (!localizacion.IsGeolocationEnabled)//Servicio de Geolocalizacion existente
            {
                DisplayAlert("Permisos Geolocalizacion", "Por favor, de Acceso a su ubicacion/geolocalizacion de manera manual en dispositivo", "OK");
            }

            var conn = CrossConnectivity.Current;
            if (!conn.IsConnected)//Servicio de Geolocalizacion existente
            {
                DisplayAlert("Internet", "Por Favor, Active la Conexion a internet para usar esta aplicacion", "OK");
            }
           
        }

        private async void Localizacion()
        {
            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            var Gps = CrossGeolocator.Current;
            
            if (Gps.IsGeolocationEnabled)//VALIDA QUE EL GPS ESTA ENCENDIDO
            {
                await DisplayAlert("Buscando Ubicacion", "Por favor, Espere un momento mientras se extrae la ubicacion", "Aceptar");

                var localizacion = CrossGeolocator.Current;
                var posicion = await localizacion.GetPositionAsync();
                txtLongitud.Text = posicion.Longitude.ToString();
                txtLatitud.Text = posicion.Latitude.ToString();
            }

            else
            {
                await DisplayAlert("Gps Desactivado", "Por favor, Active su GPS/Ubicacion", "OK");
            }

        }

        private void btnNewUbication_Clicked(object sender, EventArgs e)
        {
            // Limpiar los Text para un Nuevo Registro
            //manda a llamar al contenedor
            Localizacion();
            txtDescripcion.Text = "";
        }

        private async void btnListUbication_Clicked(object sender, EventArgs e)
        {
            CargarSitios cargar = new CargarSitios();

          
            await Navigation.PushAsync(new ListaUbicacion());
        }

        private async void btnSavedUbication_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtLongitud.Text) && String.IsNullOrEmpty(txtLatitud.Text))
            {
                await DisplayAlert("Sin Datos", "Para Obtener la Lactitud y Longitud presionar <<Nueva Ubicacion>> ", "Ok");
            }
            else if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                await DisplayAlert("Campo Vacio", "Por favor, Ingrese una Descripcion de la Ubicacion ", "Ok");
            }
            else if (!string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Sitios photoToSave = new Sitios
                {
                    Id = 0,
                    Descripcion = txtDescripcion.Text,
                    Longitud = Convert.ToDouble(txtLongitud.Text),
                    Latitud = Convert.ToDouble(txtLatitud.Text),
                    Fotografia = arrayImagen
                };
              
                try
                {

                    var client = new HttpClient();
                    var content = new StringContent(JsonConvert.SerializeObject(photoToSave), Encoding.UTF8, "application/json");
                    await DisplayAlert("Espera", " Su informacion se esta guardando por favor espere", "Aceptar");

                    HttpResponseMessage response = await client.PostAsync(URL.getUrl("/add"), content);
                    if (response.IsSuccessStatusCode)
                    {
                        //var valor = await response.Content.ReadAsStringAsync();
                        await DisplayAlert("Guardo Exitosamente", " Su informacion se guardo :D", "Aceptar");
                        
                        txtDescripcion.Text = "";
                        txtLatitud.Text = "";
                        txtLongitud.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Lo sentimos ocurrio un error" + ex.Message, "Ok");
                }


            }
            else
                await DisplayAlert("Campos vacios", "Debe asignar al menos un nombre a la foto", "Ok");
        }




        private async void btnTakePhoto_Clicked(object sender, EventArgs e)
        {
   
            var fotoTomada = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());

            if (fotoTomada != null)
            {
                //variable utilizada para almacenar la foto tomada en formado 
                arrayImagen = null;
                //BtnGuardar.IsVisible = true;
                MemoryStream memoryStream = new MemoryStream();// creamos un flujo de memoria temporal

                fotoTomada.GetStream().CopyTo(memoryStream);
                arrayImagen = memoryStream.ToArray();

                // se muestra la imagen pero aun no se guarda
                this.foto.Source = ImageSource.FromStream(() => { return fotoTomada.GetStream(); });
            }
        }


       
    }
}
