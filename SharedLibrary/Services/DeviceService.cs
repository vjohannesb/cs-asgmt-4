using Microsoft.Azure.Devices.Client;
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace SharedLibrary.Services
{
    
    public class DeviceService
    {
        // UWP App (Device Client) -> IoT Device
        public static async Task SendMessageAsync(DeviceClient deviceClient, SentMessages sentMessages)
        {
            // Anropa och vänta in resultat från OpenWeatherMap via WeatherService
            var weatherData = await WeatherService.FetchWeatherData();
            var data = new WeatherModel(weatherData.main.temp, weatherData.main.humidity);

            // Konvertera till JSON & vidare till bytes 
            string json = JsonConvert.SerializeObject(data);

            await deviceClient.SendEventAsync(new Message(Encoding.UTF8.GetBytes(json)));
            sentMessages.Insert(0, new SentMessageModel(data.Temperature, data.Humidity));
        }

        // UWP App <- Azure Function    [Receiver]
        public static async Task ReceiveMessageAsync(DeviceClient deviceClient, ReceivedMessages receivedMessages)
        {
            while (true)
            {
                // Försök hämta meddelande/"payload" från Azure Function
                var payload = await deviceClient.ReceiveAsync();

                // Uppdatera lista och radera meddelande från kö (om det finns innehåll)
                if (payload != null)
                {
                    receivedMessages.Insert(0, new ReceivedMessageModel(Encoding.UTF8.GetString(payload.GetBytes())));
                    await deviceClient.CompleteAsync(payload);
                }
            }
        }
    }
    
}
