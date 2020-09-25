using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;

namespace AzureFunction.Services
{
    class DeviceService
    {
        // Azure Function -> UWP App    [Sender]
        public static async Task SendMessageToDeviceAsync(ServiceClient serviceClient, string targetDeviceId, string message)
        {
            // Skicka meddelande "message" till Device "targetDeviceId" mha SendAsync
            var payload = new Message(Encoding.UTF8.GetBytes(message));
            await serviceClient.SendAsync(targetDeviceId, payload);
        }
    }
}
