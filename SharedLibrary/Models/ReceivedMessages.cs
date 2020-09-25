using System.Collections.ObjectModel;

namespace SharedLibrary.Models
{
    public class ReceivedMessages : ObservableCollection<ReceivedMessageModel>
    {
        public ReceivedMessages()
        {
            for (int i = 0; i < 3; i++)
                Add(new ReceivedMessageModel("UWPApp", $"Hejsan svejsan{i}"));
        }
    }
}
