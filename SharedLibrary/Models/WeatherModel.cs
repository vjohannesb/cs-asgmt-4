using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class WeatherModel
    {
        public WeatherModel(double? temp, double? hum)
        {
            Temperature = temp;
            Humidity = hum;
        }

        // Omvandling från API:ns struktur till en egen, för "snyggare" data
        public static implicit operator WeatherModel(APIModel am)
            => new WeatherModel(am.main.temp, am.main.humidity);

        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
    }
}
