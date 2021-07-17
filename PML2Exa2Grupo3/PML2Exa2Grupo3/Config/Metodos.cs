using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PML2Exa2Grupo3.Config
{
    public class Metodos
    {
        public class Meta
        {
            public int code { get; set; }
            public string requestId { get; set; }
        }

        public class Item
        {
            public int unreadCount { get; set; }
        }

        public class Notification
        {
            public string type { get; set; }
            public Item item { get; set; }
        }

        public class Contact
        {
        }

        public class LabeledLatLng
        {
            public string label { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
            public IList<LabeledLatLng> labeledLatLngs { get; set; }
            public int distance { get; set; }
            public string cc { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string contextLine { get; set; }
            public long contextGeoId { get; set; }
            public IList<string> formattedAddress { get; set; }
        }

        public class Icon
        {
            public string prefix { get; set; }
            public string mapPrefix { get; set; }
            public string suffix { get; set; }
        }

        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
            public string pluralName { get; set; }
            public string shortName { get; set; }
            public Icon icon { get; set; }
            public bool primary { get; set; }
        }

        public class Stats
        {
            public int tipCount { get; set; }
            public int usersCount { get; set; }
            public int checkinsCount { get; set; }
        }

        public class BeenHere
        {
            public int lastCheckinExpiredAt { get; set; }
        }

        public class Specials
        {
            public int count { get; set; }
            public IList<object> items { get; set; }
        }

        public class HereNow
        {
            public int count { get; set; }
            public string summary { get; set; }
            public IList<object> groups { get; set; }
        }

        public class Venue
        {
            public string id { get; set; }
            public string name { get; set; }
            public Contact contact { get; set; }
            public Location location { get; set; }
            public string canonicalUrl { get; set; }
            public string canonicalPath { get; set; }
            public IList<Category> categories { get; set; }
            public bool verified { get; set; }
            public Stats stats { get; set; }
            public bool venueRatingBlacklisted { get; set; }
            public BeenHere beenHere { get; set; }
            public Specials specials { get; set; }
            public HereNow hereNow { get; set; }
            public string referralId { get; set; }
            public IList<object> venueChains { get; set; }
            public bool hasPerk { get; set; }
        }

        public class Response
        {
            public IList<Venue> venues { get; set; }
            public bool confident { get; set; }
        }

        public class Places
        {
            public IList<Notification> notifications { get; set; }
            public Response response { get; set; }
        }

        public async static Task<List<Venue>> getSites(Double platitud, Double plongitud, Double pdistance)
        {
            //lista principal que obtiene toda la api
            List<Venue> sitios = new List<Venue>();
            //se crea otra lista donde solo colocaremos los que pasaremos con un distancia fija
            List<Venue> sitioscercanos = new List<Venue>();

            //extraemos la api
            using (HttpClient cliente = new HttpClient())
            {
                var Respuesta = await cliente.GetAsync(Ubicaciones.getUrl(platitud, plongitud));

                if (Respuesta.IsSuccessStatusCode)
                {
                    var json = Respuesta.Content.ReadAsStringAsync().Result;
                    var lugares = JsonConvert.DeserializeObject<Places>(json);

                    sitios = lugares.response.venues as List<Venue>;
                }
            }

           // recoremos los sitios y creamos una lista que hara la lectura por cada uno de la lista anterior 
            foreach (var sitio in sitios)
            {
                //a esa lista le mandamos  la locacion que valida y le decimos que si es menor al parametro que le enviamos
                if (sitio.location.distance<= pdistance)
                {
                    //agregamos a la lista que creamos cada uno de los sitios
                    sitioscercanos.Add(sitio);
                }
            }
            return sitioscercanos;


        }


    }


}
