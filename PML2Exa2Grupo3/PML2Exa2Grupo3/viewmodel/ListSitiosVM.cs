using Newtonsoft.Json;
using PML2Exa2Grupo3.Config;
using PML2Exa2Grupo3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace PML2Exa2Grupo3.viewmodel
{
    public class ListSitiosVM 
    { 
        public ObservableCollection<Sitios> SitiosList { get; set; }
        public ICommand DeleteCommand { protected set; get; }
        public ICommand SeeCommand { protected set; get; }
        public ICommand VerUbicaciones { protected set; get; }


        public ListSitiosVM(INavigation navigation)
        {

            HttpClient cliente = new HttpClient();
            try
            {
                var respuesta = cliente.GetAsync(URL.getUrl("/sites")).Result;
                var json = respuesta.Content.ReadAsStringAsync().Result;
                var listasitios = JsonConvert.DeserializeObject<List<Sitios>>(json);
                SitiosList = new ObservableCollection<Sitios>(listasitios);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error", "Error " + e.Message, "Ok");
            }
        }
        public ListSitiosVM()
        {

            HttpClient cliente = new HttpClient();
            try
            {
                var respuesta = cliente.GetAsync(URL.getUrl("/sites")).Result;
                var json = respuesta.Content.ReadAsStringAsync().Result;
                var listasitios = JsonConvert.DeserializeObject<List<Sitios>>(json);
                SitiosList = new ObservableCollection<Sitios>(listasitios);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error", "Error " + e.Message, "Ok");
            }


            //DeleteCommand = new Command<Sitios>(async (key) =>
            //{
              //  Sitios SelectPictures = key as Sitios;
                //Uri uri = new Uri(string.Format(URL.getUrl("/delete/"+SelectPictures.Id)));
                //HttpResponseMessage response = await cliente.DeleteAsync(uri);
                //var result = await cliente.DeleteAsync(uri);
               
                //if (result.IsSuccessStatusCode)
                //{

                  //  SitiosList.Remove(SelectPictures);
                    //Debug.WriteLine("successfully deleted.");
                //}


            //});

            //SeeCommand = new Command<Sitios>(async (key) =>
            //{
               // Sitios SelectPictures = key as Sitios;
               // var verFourSquare = new ListaFourSquare(SelectPictures.Latitud,SelectPictures.Longitud);
                
           // });
        
        }
       
      
        

    }

    }


