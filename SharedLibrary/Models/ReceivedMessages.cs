using System;
using System.Collections.ObjectModel;

namespace SharedLibrary.Models
{
    public class ReceivedMessages : ObservableCollection<ReceivedMessageModel> { }

    public class ReceivedMessageModel
    {
        public ReceivedMessageModel(string message) 
            => Message = message;

        public string Message { get; set; }
        public string DateTimeReceived => DateTime.Now.ToString("G");
    }
}
