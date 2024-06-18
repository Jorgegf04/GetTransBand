using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesTransBand
{
    class ConveyorBeltsByAsset : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private int idActive;
        private int idBelt;
        private int longitude;
        private int wide;
        private bool closed;

        public ConveyorBeltsByAsset(int id, string name, int idActive, int idBelt, int longitude, int wide, bool closed)
        {
            this.id = id;
            this.name = name;
            this.idActive = idActive;
            this.idBelt = idBelt;
            this.longitude = longitude;
            this.wide = wide;
            this.closed = closed;
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public int IdActive
        {
            get => idActive;
            set
            {
                idActive = value;
                NotifyPropertyChanged("IdActive");
            }
        }
        public int IdBelt
        {
            get => idBelt;
            set
            {
                idBelt = value;
                NotifyPropertyChanged("IdBelt");
            }
        }

        public int Longitude
        {
            get => longitude;
            set
            {
                longitude = value;
                NotifyPropertyChanged("Longitude");
            }
        }

        public int Wide
        {
            get => wide;
            set
            {
                wide = value;
                NotifyPropertyChanged("Wide");
            }
        }

        public bool Closed
        {
            get => closed;
            set
            {
                closed = value;
                NotifyPropertyChanged("Closed");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
