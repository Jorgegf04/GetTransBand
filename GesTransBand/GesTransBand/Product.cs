using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesTransBand
{
    public class Product : INotifyPropertyChanged
    {
        private int idProduct;
        private int idLine;
        private string desProduct;
        private DateTime fechaLote;

        public Product(int idProduct, int idLine, string desProduct, DateTime fechaLote)
        {
            IdProduct = idProduct;
            IdLine = idLine;
            DesProduct = desProduct;
            FechaLote = fechaLote;
        }

        public int IdProduct
        {
            get => idProduct;
            set
            {
                idProduct = value;
                NotifyPropertyChanged("IdProduct");
            }
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

        public string DesProduct
        {
            get => desProduct;
            set
            {
                desProduct = value;
                NotifyPropertyChanged("DesProduct");
            }
        }

        public DateTime FechaLote
        {
            get => fechaLote;
            set
            {
                fechaLote = value;
                NotifyPropertyChanged("FechaLote");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}