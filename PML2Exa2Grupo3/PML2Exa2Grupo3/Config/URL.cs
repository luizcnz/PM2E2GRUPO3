using System;
using System.Collections.Generic;
using System.Text;

namespace PML2Exa2Grupo3.Config
{
    class URL
    {
        private static string urlGeneral = "https://apimovil2.herokuapp.com/exam";

        public static String getUrl(string endpoint)
        {
            return String.Concat(urlGeneral, endpoint);
        }
    }

}
