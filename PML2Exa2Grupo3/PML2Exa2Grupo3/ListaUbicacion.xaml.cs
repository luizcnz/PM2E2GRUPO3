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

        public ListaUbicacion()
        {

            InitializeComponent();
        

       
        }

        
<<<<<<< HEAD
        InitializeComponent();
        }

        protected override void OnAppearing()
=======

        protected async override void OnAppearing()
>>>>>>> 50b29916deff5585fb26d8b5fd5dc17d466e4d70
        {
            base.OnAppearing();
       
        }

    }

}