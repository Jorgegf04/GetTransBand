using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesTransBand
{
    public class User : INotifyPropertyChanged, IPerson
    {
        private int idUser;
        private int idCompany;
        private string name;
        private string surname;
        private string telephone;
        private string email;
        private string companyName;

        public User(int idUser, int idCompany, string name, string surname, string telephone, string email, string companyName)
        {
            IdUser = idUser;
            IdCompany = idCompany;
            Name = name;
            Surname = surname;
            Telephone = telephone;
            Email = email;
            CompanyName = companyName;
        }

        public int IdUser
        {
            get => idUser;
            set
            {
                idUser = value;
                NotifyPropertyChanged("IdUser");
            }
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
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                NotifyPropertyChanged("Surname");
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
        public string Email
        {
            get => email;
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        public string CompanyName
        {
            get => companyName;
            set
            {
                companyName = value;
                NotifyPropertyChanged("CompanyName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
