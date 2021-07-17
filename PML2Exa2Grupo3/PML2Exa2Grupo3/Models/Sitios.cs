using Newtonsoft.Json;
using PML2Exa2Grupo3.Config;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PML2Exa2Grupo3.Models
{
    public class Sitios
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("latitud")]
        public double Latitud { get; set; }

        [JsonProperty("longitud")]
        public double Longitud { get; set; }

        [JsonProperty("foto")]
        public byte [] Fotografia { get; set; }
       
        [JsonProperty("urlfoto")]
        public string UrlFoto { get; set; }



        public async static Task<List<Sitios>> getValues()
        {
            List<Sitios> sitioscercanos = new List<Sitios>();

            using (HttpClient cliente = new HttpClient())
            {
                var respuesta = await cliente.GetAsync(URL.getUrl("/sites"));

                if (respuesta.IsSuccessStatusCode)
                {

                    var json = respuesta.Content.ReadAsStringAsync().Result;

                    var Lugares = JsonConvert.DeserializeObject<Sitios>(json.ToString());

                }
            }

            return sitioscercanos;
        }
    }
}
