using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesTransBand
{
    class ConveyorBeltAssembly : INotifyPropertyChanged
    {
        private int idActive;
        private int idAssembler;
        private DateTime dateOfAssembly;

        public int IdActive
        {
            get => idActive;
            set
            {
                idActive = value;
                NotifyPropertyChanged("IdActive");
            }
        }

        public int IdAssembler
        {
            get => idAssembler;
            set
            {
                idAssembler = value;
                NotifyPropertyChanged("IdAssembler");
            }
        }

        public DateTime DateOfAssembly
        {
            get => dateOfAssembly;
            set
            {
                dateOfAssembly = value;
                NotifyPropertyChanged("DateOfAssembly");
            }
        }

        public ConveyorBeltAssembly(int idActive, int idAssembler)
        {
            this.idActive = idActive;
            this.idAssembler = idAssembler;
            this.dateOfAssembly = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
