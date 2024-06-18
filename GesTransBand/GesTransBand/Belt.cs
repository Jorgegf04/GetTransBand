using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GesTransBand
{
    public class Belt : INotifyPropertyChanged
    {
        private int idBelt;
        private string nameBelt;
        private string dataSheet;
        private string certificate;

        public Belt(int idBelt, string nameBelt, string dataSheet, string certificate)
        {
            IdBelt = idBelt;
            NameBelt = nameBelt;
            DataSheet = dataSheet;
            Certificate = certificate;
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

        public string NameBelt
        {
            get => nameBelt;
            set
            {
                nameBelt = value;
                NotifyPropertyChanged("NameBelt");
            }
        }

        public string DataSheet
        {
            get => dataSheet;
            set
            {
                dataSheet = value;
                NotifyPropertyChanged("DataSheet");
            }
        }
        public string Certificate
        {
            get => certificate;
            set
            {
                certificate = value;
                NotifyPropertyChanged("Certificate");
            }
        }

        public static List<Belt> GetBelts()
        {
            List<Belt> belts = new List<Belt>();

            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT * FROM Belt";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int belt = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string fichaTecnica = reader.GetString(2);
                        string certificado = reader.GetString(3);

                        belts.Add(new Belt(belt, name, fichaTecnica, certificado));
                    }
                }
            }
            return belts;
        }

        internal static void UpdateBelt(Belt cinta)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                UPDATE Belt 
                SET NameBelt = @NameBelt, DataSheet = @DataSheet, Certificate = @Certificate
                WHERE IdBelt = @IdBelt";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdBelt", cinta.IdBelt);
                    command.Parameters.AddWithValue("@NameBelt", cinta.NameBelt);
                    command.Parameters.AddWithValue("@DataSheet", cinta.DataSheet);
                    command.Parameters.AddWithValue("@Certificate", cinta.Certificate);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteBelt(int idBelt)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkReferencesQuery = @"
                    SELECT COUNT(*) 
                    FROM ConveyorBeltsByAsset 
                    WHERE idBelt = @IdBelt";

                    using (SqlCommand checkCommand = new SqlCommand(checkReferencesQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@IdBelt", idBelt);
                        int referenceCount = (int)checkCommand.ExecuteScalar();

                        if (referenceCount > 0)
                        {
                            MessageBox.Show("No se puede eliminar la cinta porque está referenciado en la tabla ConveyorBeltsByAsset.");
                            return;
                        }
                    }

                    string deleteQuery = "DELETE FROM Belt WHERE IdCinta = @IdBelt";

                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@IdBelt", idBelt);
                        deleteCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("La cinta se ha eliminado correctamente.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Se ha producido un error al acceder a la base de datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error inesperado: " + ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
