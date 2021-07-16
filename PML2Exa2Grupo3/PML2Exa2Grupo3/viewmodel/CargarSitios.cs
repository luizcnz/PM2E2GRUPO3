using Newtonsoft.Json;
using PML2Exa2Grupo3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PML2Exa2Grupo3.viewmodel
{
    
    public class CargarSitios 
    {
        HttpClient _client;

        public CargarSitios()
        {
            _client = new HttpClient();

        }

        public async Task<List<Sitios>> GetSites(string uri)
        {
            List<Sitios> Sitios = null;
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {

                    string content = await response.Content.ReadAsStringAsync();
                    Sitios = JsonConvert.DeserializeObject<List<Sitios>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return Sitios;
        }
    }
}
