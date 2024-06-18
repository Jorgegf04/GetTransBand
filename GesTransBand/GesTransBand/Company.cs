using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesTransBand
{
    public class Company : INotifyPropertyChanged
    {

        private int idCompany;
        private string name;
        private string telephone;
        private string emailCompany;
        private bool externa;
        private string webCompany;
       

        public Company(int idCompany, string name, string telephone, string emailCompany, bool externa, string webCompany)
        {
            IdCompany = idCompany;
            Name = name;
            Telephone = telephone;
            EmailCompany = emailCompany;
            Externa = externa;
            WebCompany = webCompany;
        }

        public int IdCompany
        {
            get => idCompany;
            set
            {
                idCompany = value;
                NotifyPropertyChanged("IdCompany");
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

        public string Telephone
        {
            get => telephone;
            set
            {
                telephone = value;
                NotifyPropertyChanged("Telephone");
            }
        }
        public string EmailCompany
        {
            get => emailCompany;
            set
            {
                emailCompany = value;
                NotifyPropertyChanged("EmailCompany");
            }
        }
        public bool Externa
        {
            get => externa;
            set
            {
                externa = value;
                NotifyPropertyChanged("Externa");
            }
        }
        public string WebCompany
        {
            get => webCompany;
            set
            {
                webCompany = value;
                NotifyPropertyChanged("WebCompany");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
