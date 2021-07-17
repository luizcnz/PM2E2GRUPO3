using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace PML2Exa2Grupo3.Converters
{
    public class ConvertStringToImage : IValueConverter

    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string foto = $"{value}";
            if (!string.IsNullOrEmpty(foto))
            {

                byte[] imgByte = Encoding.ASCII.GetBytes(foto);
                return new MemoryStream(imgByte);
            }
            else
                return new MemoryStream();
                
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
