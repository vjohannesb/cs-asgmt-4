using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;

namespace SharedLibrary.Models
{
    public class ReceivedMessages : ObservableCollection<ReceivedMessageModel>
    {
        public ReceivedMessages(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Add(new ReceivedMessageModel("UWPApp", $"Hejsan svejsan{i}"));
            }
        }
    }
}
