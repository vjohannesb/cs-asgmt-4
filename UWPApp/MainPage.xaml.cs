using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SharedLibrary.Services;
using SharedLibrary.Models;
using SharedLibrary;
using Microsoft.Azure.Devices.Client;


namespace UWPApp
{
    public sealed partial class MainPage : Page
    {
        private static readonly DeviceClient deviceClient =
            DeviceClient.CreateFromConnectionString(Config.IotDeviceConnectionString, TransportType.Mqtt);

        ReceivedMessages receivedMessages = new ReceivedMessages();
        SentMessages sentMessages = new SentMessages();

        public MainPage()
        {
            this.InitializeComponent();

            DeviceService.ReceiveMessageAsync(deviceClient, receivedMessages).GetAwaiter();
        }


        private void btnSendMessage_Click(object sender, RoutedEventArgs e) 
            => DeviceService.SendMessageAsync(deviceClient, sentMessages).GetAwaiter();

        private async void btnUpdateData_Click(object sender, RoutedEventArgs e)
        {            
            var weatherData = await WeatherService.FetchWeatherData();
            tbxTemperature.Text = weatherData.main.temp.ToString();
            tbxHumidity.Text = weatherData.main.humidity.ToString();
        }

        private void btnClearSentMessages_Click(object sender, RoutedEventArgs e) 
            => sentMessages.Clear();

        private void btnClearReceivedMessages_Click(object sender, RoutedEventArgs e)
            => receivedMessages.Clear();

    }
}
