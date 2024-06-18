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
    public class Active : INotifyPropertyChanged
    {
        private int idActive;
        private int idLine;
        private int idZone;
        private string desActive;
        private string imageActive;

        public Active(int idActive, int idLine, int idZone, string desActive, string imageActive)
        {
            IdActive = idActive;
            IdLine = idLine;
            IdZone = idZone;
            DesActive = desActive;
            ImageActive = imageActive;
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

        public int IdLine
        {
            get => idLine;
            set
            {
                idLine = value;
                NotifyPropertyChanged("IdLine");
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

        public string DesActive
        {
            get => desActive;
            set
            {
                desActive = value;
                NotifyPropertyChanged("DesActive");
            }
        }

        public string ImageActive
        {
            get => imageActive;
            set
            {
                imageActive = value;
                NotifyPropertyChanged("ImageActive");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static List<ActiveDTO> GetActives()
        {
            List<ActiveDTO> actives = new List<ActiveDTO>();

            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                SELECT Active.IdActive, ProductionLine.DesLine, Zone.DesZone, Active.DesActive, Active.ImageActive
                    FROM Active
                        JOIN ProductionLine ON Active.IdLine = ProductionLine.IdLine
                        JOIN Zone ON Active.IdZone = Zone.IdZone";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int active = reader.GetInt32(0);
                        string line = reader.GetString(1);
                        string zone = reader.GetString(2);
                        string description = reader.GetString(3);
                        string image = reader.GetString(4);

                        actives.Add(new ActiveDTO(active, line, zone, description, image));
                    }
                }
            }
            return actives;
        }

        public static void DeleteActive(int idActive)
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
                    WHERE IdActive = @IdActive";

                    using (SqlCommand checkCommand = new SqlCommand(checkReferencesQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@IdActive", idActive);
                        int referenceCount = (int)checkCommand.ExecuteScalar();

                        if (referenceCount > 0)
                        {
                            MessageBox.Show("No se puede eliminar el activo porque está referenciado en la tabla ConveyorBeltsByAsset.");
                            return; 
                        }
                    }

                    string deleteQuery = "DELETE FROM Active WHERE IdActive = @IdActive";

                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@IdActive", idActive);
                        deleteCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Activo eliminado correctamente."); 
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


        public static void UpdateActive(ActiveDTO active)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                UPDATE Active 
                SET IdLine = @IdLine, 
                IdZone = @IdZone, 
                DesActive = @DesActive, 
                ImageActive = @ImageActive
                WHERE IdActive = @IdActive";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int idLine = GetIdLineByName(connection, active.DesLine);
                    int idZone = GetIdZoneByName(connection, active.DesZone);

                    if (idLine == -1)
                    {
                        throw new Exception($"No se encontró una línea de producción con el nombre '{active.DesLine}'");
                    }

                    if (idZone == -1)
                    {
                        throw new Exception($"No se encontró una zona con el nombre '{active.DesZone}'");
                    }

                    command.Parameters.AddWithValue("@IdActive", active.IdActive);
                    command.Parameters.AddWithValue("@IdLine", idLine);
                    command.Parameters.AddWithValue("@IdZone", idZone);
                    command.Parameters.AddWithValue("@DesActive", active.DesActive);
                    command.Parameters.AddWithValue("@ImageActive", active.ImageActive);
                    command.ExecuteNonQuery();
                }
            }
        }

        private static int GetIdLineByName(SqlConnection connection, string desLine)
        {
            string query = "SELECT IdLine FROM ProductionLine WHERE DesLine = @DesLine";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DesLine", desLine);
                var result = command.ExecuteScalar();
                return result != null ? (int)result : -1;
            }
        }

        private static int GetIdZoneByName(SqlConnection connection, string desZone)
        {
            string query = "SELECT IdZone FROM Zone WHERE DesZone = @DesZone";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DesZone", desZone);
                var result = command.ExecuteScalar();
                return result != null ? (int)result : -1;
            }
        }

    }
}
