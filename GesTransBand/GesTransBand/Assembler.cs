﻿//using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesTransBand
{
    public class Assembler : INotifyPropertyChanged, IPerson
    {
        private int idAssembler;
        private int idCompany;
        private string name;
        private string surname;
        private string telephone;
        private string email;
        private string companyName;

        public Assembler(int idAssembler, int idCompany, string name, string surname, string telephone, string email, string companyName)
        {
            IdAssembler = idAssembler;
            IdCompany = idCompany;
            Name = name;
            Surname = surname;
            Telephone = telephone;
            Email = email;
            CompanyName = companyName;
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
