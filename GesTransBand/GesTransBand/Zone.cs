using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesTransBand 
{
    public class Zone : INotifyPropertyChanged
    {
        private int idZone;
        private string desZone;

        public Zone(int idZone, string desZone)
        {
            IdZone = idZone;
            DesZone = desZone;
        }

        public int IdZone
        {
            get => idZone;
            set
            {
                idZone = value;
                NotifyPropertyChanged("IdZone");
            }
        }
        public string DesZone
        {
            get => desZone;
            set
            {
                desZone = value;
                NotifyPropertyChanged("DesZone");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 


