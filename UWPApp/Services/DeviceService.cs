using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPApp.Services
{
    public class DeviceService
    {
        // UWP App (Device Client) -> IoT Device
        public static async Task SendMessageAsync(DeviceClient deviceClient)
        {
            // Anropa och vänta in resultat från OpenWeatherMap via WeatherService
            var weatherData = await WeatherService.FetchWeatherData();

            // "Omformatera" till (nullable) TemperatureModel för en egen struktur
            var data = new TemperatureModel(temp: weatherData?.main?.temp, hum: weatherData?.main?.humidity);

            // Konvertera till JSON & vidare till bytes (spara json för konsolutskrift) 
            string json = JsonConvert.SerializeObject(data);
            var payload = new Message(Encoding.UTF8.GetBytes(json));

            await deviceClient.SendEventAsync(payload);

            // För att inte kunna spamma
            await Task.Delay(5 * 1000);
        }

        // UWP App <- Azure Function    [Receiver]
        public static async Task<ReceivedMessageModel> ReceiveMessageAsync(DeviceClient deviceClient, Action<ReceivedMessageModel> updateList)
        {
            while (true)
            {
                // Försök hämta meddelande/"payload" från Azure Function
                var payload = await deviceClient.ReceiveAsync();

                // Returnera payload (som ReceivedMessage) om det finns innehåll, annars gå vidare till nästa iteration
                if (payload != null)
                {
                    Debug.WriteLine("\n-----------------\nMessage received!\n---------------\n");
                    updateList(JsonConvert.DeserializeObject<ReceivedMessageModel>(Encoding.UTF8.GetString(payload.GetBytes())));
                    await deviceClient.CompleteAsync(payload);
                }
            }
        }
    }
}
