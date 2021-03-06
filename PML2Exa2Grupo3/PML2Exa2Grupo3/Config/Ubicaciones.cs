using System;
using System.Collections.Generic;
using System.Text;

namespace PML2Exa2Grupo3.Config
{
   
    public class Ubicaciones
    {

        public const String IDFoursquare = "SJYNWEB44YOBAAY0VIZTPKE43VNXJWTXL3NH5MNAG4FZAZPV";
        public const String SecreteFoursquare = "I3KD5CINMV4YS2FUYQCLNWGJV0MSYQDU5Y5EGWI4NVQSLNBL";

        public const String apifoursquare = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";


        public static String getUrl(Double latitud, Double longitud)
        {
            return String.Format(apifoursquare, latitud, longitud, IDFoursquare,SecreteFoursquare, DateTime.Now.ToString("yyyyMMdd"));
        }
    }

   
}
