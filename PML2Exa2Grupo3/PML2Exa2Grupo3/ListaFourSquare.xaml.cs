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
        }
    }
}