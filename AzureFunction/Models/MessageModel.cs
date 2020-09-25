using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunction.Models
{
    public class MessageModel
    {
        public string TargetDeviceID { get; set; }
        public string Message { get; set; }
    }
}
