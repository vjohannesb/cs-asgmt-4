using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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

        public ReceivedMessages receivedMessages = new ReceivedMessages(5);

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClearSentMessages_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClearReceivedMessages_Click(object sender, RoutedEventArgs e)
        {
            while (receivedMessages.Count > 0)
                receivedMessages.RemoveAt(0);

            Console.WriteLine($"Objects: {receivedMessages.Count}");
            Console.WriteLine($"List: {receivedMessages}");
        }
    }
}
