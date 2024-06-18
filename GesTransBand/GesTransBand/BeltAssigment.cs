using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;

namespace GesTransBand
{
    public class BeltAssignment : INotifyPropertyChanged
    {
        private int idBeltAssignment;
        private int idBelt;
        private int idZone;
        private int idLine;

        public BeltAssignment(int idBeltAssignment, int idBelt, int idZone, int idLine)
        {
            IdBeltAssignment = idBeltAssignment;
            IdBelt = idBelt;
            IdZone = idZone;
            IdLine = idLine;
        }

        public int IdBeltAssignment
        {
            get => idBeltAssignment;
            set
            {
                idBeltAssignment = value;
                NotifyPropertyChanged("IdBeltAssignment");
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

        public int IdZone
        {
            get => idZone;
            set
            {
                idZone = value;
                NotifyPropertyChanged("IdZone");
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static List<BeltAssignment> GetBeltAssignments()
        {
            List<BeltAssignment> beltAssignments = new List<BeltAssignment>();

            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT * FROM BeltAssignment";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int idBeltAssignment = reader.GetInt32(0);
                        int idBelt = reader.GetInt32(1);
                        int idZone = reader.GetInt32(2);
                        int idLine = reader.GetInt32(3);

                        beltAssignments.Add(new BeltAssignment(idBeltAssignment, idBelt, idZone, idLine));
                    }
                }
            }
            return beltAssignments;
        }
    }
}

