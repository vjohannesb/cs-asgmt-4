﻿using System;

namespace SharedLibrary.Models
{
    public class ReceivedMessageModel
    {
        public ReceivedMessageModel(string targetdeviceid, string message)
        {
            TargetDeviceId = targetdeviceid;
            Message = message;
            DateTimeReceived = DateTime.Now.ToString("G");
        }

        public ReceivedMessageModel()
        {
            DateTimeReceived = DateTime.Now.ToString("G");
        }

        public string TargetDeviceId { get; set; }
        public string Message { get; set; }
        public string DateTimeReceived { get; set; }
    }
}
