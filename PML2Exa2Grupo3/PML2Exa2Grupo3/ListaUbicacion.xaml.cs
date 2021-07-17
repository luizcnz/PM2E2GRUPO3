﻿using System;
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

namespace PML2Exa2Grupo3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaUbicacion : ContentPage
    {

        public List<Sitios> Sitios { get; set; }
        public ICommand DeleteCommand { protected set; get; }
        public ICommand SeeCommand { protected set; get; }
        public ListaUbicacion()
        {
            DeleteCommand = new Command<Sitios>(async (key) =>
             {
                 Sitios SelectPictures = key as Sitios;
                 await DisplayAlert("info", SelectPictures.Id.ToString(), "OK");
             });

            SeeCommand = new Command<Sitios>(async (key) =>
            {
                Sitios SelectPictures = key as Sitios;

                await DisplayAlert("info", SelectPictures.Id.ToString(), "OK");
            });
            CargarSitios cargar = new CargarSitios();

            ListUbications.ItemsSource = cargar.GetSites(URL.getUrl("/sites")).Result;
        
        InitializeComponent();
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();
          
        }

    }

}