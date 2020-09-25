using Microsoft.Azure.Devices.Client;
using SharedLibrary.Models;
using SharedLibrary.Services;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409


/*
 * - Applikation ska skicka ett meddelande till Azure IoT Hub
 * - - Meddelandet ska innehålla temperatur och luftfuktighet
 * 
 * + VG +
 * - Applikation ska lista meddelanden som skickas till UWP
 * - - Via Azure Functions
 */

namespace UWPApp
{
    public sealed partial class MainPage : Page
    {
        private static readonly DeviceClient deviceClient =
            DeviceClient.CreateFromConnectionString(Config.IotDeviceConnectionString, TransportType.Mqtt);

        SolidColorBrush whiteColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        SolidColorBrush blackColor = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        WeatherModel weatherModel = new WeatherModel();
        TemperatureModel temperatureModel = new TemperatureModel(0d, 0d);

        public ReceivedMessages receivedMessages = new ReceivedMessages();

        public MainPage()
        {
            this.InitializeComponent();

            DeviceService.ReceiveMessageAsync(deviceClient, UpdateReceivedMessagesList).GetAwaiter();
        }

        public void UpdateReceivedMessagesList(ReceivedMessageModel receivedMessage)
        {
            receivedMessages.Add(receivedMessage);
        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e) 
            => DeviceService.SendMessageAsync(deviceClient).GetAwaiter();

        private async void btnUpdateData_Click(object sender, RoutedEventArgs e)
        {
            tbUpdating.Foreground = blackColor;
            var weatherData = await WeatherService.FetchWeatherData();

            tbxTemperature.Text = weatherData.main.temp.ToString();
            tbxHumidity.Text = weatherData.main.humidity.ToString();

            await Task.Delay(1000);
            tbUpdating.Foreground = whiteColor;

        }

        private void btnClearSentMessages_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClearReceivedMessages_Click(object sender, RoutedEventArgs e)
        {
            while (receivedMessages.Count > 0)
                receivedMessages.RemoveAt(0);
        }
    }
}
