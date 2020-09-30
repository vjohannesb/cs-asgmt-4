using System;
using System.Collections.ObjectModel;

namespace SharedLibrary.Models
{
    public class SentMessages : ObservableCollection<SentMessageModel> { }

    public class SentMessageModel
    {
        public SentMessageModel(double? temp, double? hum)
        {
            Temperature = temp;
            Humidity = hum;
        }

        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
        public string DateTimeSent => DateTime.Now.ToString("G");
    }
}
