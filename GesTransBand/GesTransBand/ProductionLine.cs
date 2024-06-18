using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesTransBand
{
    class ProductionLine : INotifyPropertyChanged
    {
        private int idLine;
        private string desLine;

        public ProductionLine(int idLine, string desLine)
        {
            this.idLine = idLine;
            this.desLine = desLine;
        }

        public int IdLine
        {
            get => idLine;
            set
            {
                idLine = value;
                NotifyPropertyChanged("IdLine");
            }
        }
        public string DesLine
        {
            get => desLine;
            set
            {
                desLine = value;
                NotifyPropertyChanged("DesLine");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
