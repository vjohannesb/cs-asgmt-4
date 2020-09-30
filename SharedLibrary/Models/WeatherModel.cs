using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    class WeatherModel
    {
        public WeatherModel(double? temp, double? hum)
        {
            Temperature = temp;
            Humidity = hum;
        }

        // För "snyggare" get
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
    }
}
