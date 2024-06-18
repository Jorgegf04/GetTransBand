using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GesTransBand
{    public partial class NewBelt : Window
    {
        public NewBelt()
        {
            InitializeComponent();
        }

        private string GetConnectionString()
        {
            return "Server=PCJorge\\PCJORGE4;Database=MiBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            string cinta = descripcionCintaTextBox.Text;

            if (string.IsNullOrEmpty(cinta))
            {
                MessageBox.Show("Por favor, introduce el nombre descriptivo de la cinta.");
                return;
            }

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Belt WHERE NameBelt = @cinta";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cinta", cinta);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        codigoCintaTextBox.Text = reader["IdBelt"].ToString();
                        descripcionCintaTextBox.Text = reader["NameBelt"].ToString();
                        fichaTecnicaCintaTextBox.Text = reader["DataSheet"].ToString();
                        certificadoCintaTextBox.Text = reader["Certificate"].ToString();
                        MessageBox.Show($"La cinta {cinta} ya existe.");
                    }
                    else
                    { 
                        buscarButton.IsEnabled = false;
                        MessageBox.Show("No se ha encontrado el activo.");
                        insertarButton.IsEnabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar activo: {ex.Message}");
                }
            }
        }

        private void InsertarButton_Click(object sender, RoutedEventArgs e)
        {
            string nombre = descripcionCintaTextBox.Text;
            string fichaTecnica = fichaTecnicaCintaTextBox.Text;
            string certificado = certificadoCintaTextBox.Text;

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Belt (NameBelt, DataSheet, Certificate) VALUES (@nombre, @fichaTecnica, @certificado)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@fichaTecnica", fichaTecnica);
                command.Parameters.AddWithValue("@certificado", certificado);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("La cinta se ha introducido con éxito.");
                    insertarButton.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar la cinta: {ex.Message}");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
