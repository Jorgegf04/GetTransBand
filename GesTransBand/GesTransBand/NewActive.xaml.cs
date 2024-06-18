using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace GesTransBand
{
    public partial class NewActive : Window
    {
        private readonly string imageDirectory = @"C:\Users\jjgui\OneDrive\Escritorio\GesTransBand\GesTransBand\GesTransBand\Activos";

        public NewActive()
        {
            InitializeComponent();
            LoadComboBoxes();
            LoadImages();
        }

        private void LoadComboBoxes()
        {
            LoadComboBoxData("SELECT IdLine, DesLine FROM ProductionLine", líneaComboBox);
            LoadComboBoxData("SELECT IdZone, DesZone FROM Zone", zonaComboBox);
        }

        private void LoadImages()
        {
            if (Directory.Exists(imageDirectory))
            {
                var files = Directory.GetFiles(imageDirectory, "*.jpg");
                foreach (var file in files)
                {
                    imagenComboBox.Items.Add(new { FileName = Path.GetFileName(file), FullPath = file });
                }

  
                imagenComboBox.DisplayMemberPath = "FileName";
                imagenComboBox.SelectedValuePath = "FullPath";
            }
            else
            {
                MessageBox.Show("El directorio de imágenes no existe.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void LoadComboBoxData(string query, ComboBox comboBox)
        {
            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("La consulta no puede estar vacía.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (comboBox == null)
            {
                MessageBox.Show("El ComboBox no puede ser nulo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    comboBox.Items.Clear();

                    while (reader.Read())
                    {
                        if (comboBox == líneaComboBox)
                        {
                            comboBox.Items.Add(new ProductionLine((int)reader["IdLine"], (string)reader["DesLine"]));
                        }
                        else if (comboBox == zonaComboBox)
                        {
                            comboBox.Items.Add(new Zone((int)reader["IdZone"], (string)reader["DesZone"]));
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"Error de base de datos: {sqlEx.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine(sqlEx.StackTrace);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        private string GetConnectionString()
        {
            return "Server=PCJorge\\PCJORGE4;Database=MiBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            string activo = activoTextBox.Text;

            if (string.IsNullOrEmpty(activo))
            {
                MessageBox.Show("Por favor, introduce el nombre del activo.");
                return;
            }

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT IdActive, IdLine, IdZone, DesActive, ImageActive FROM Active WHERE IdActive = @activo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@activo", activo);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show($"El activo {activo} ya existe.");

                        líneaComboBox.SelectedValue = reader["IdLine"];
                        líneaComboBox.IsEnabled = false;
                        zonaComboBox.SelectedValue = reader["IdZone"];
                        zonaComboBox.IsEnabled = false;
                        descripcionTextBox.Text = reader["DesActive"].ToString();
                        descripcionTextBox.IsReadOnly = true;
                        imagenComboBox.SelectedValue = reader["ImageActive"].ToString();
                        imagenComboBox.IsEnabled = false;
                        insertarButton.IsEnabled = false;
                    }
                    else
                    {

                        MessageBox.Show("No se ha encontrado el activo.");

                        ClearFields();
                        líneaComboBox.IsEnabled = true;
                        zonaComboBox.IsEnabled = true;
                        descripcionTextBox.Clear();
                        descripcionTextBox.IsReadOnly = false;
                        imagenComboBox.IsEnabled = true;
                        insertarButton.IsEnabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar activo: {ex.Message}");
                }
            }
        }

        private void ClearFields()
        {
            líneaComboBox.SelectedIndex = -1;
            zonaComboBox.SelectedIndex = -1;
            descripcionTextBox.Clear();
            imagenComboBox.SelectedIndex = -1;
        }

        private void InsertarButton_Click(object sender, RoutedEventArgs e)
        {
            string activo = activoTextBox.Text;
            int idLine = (líneaComboBox.SelectedItem as ProductionLine).IdLine;
            int idZone = (zonaComboBox.SelectedItem as Zone).IdZone;
            string descripcion = descripcionTextBox.Text;
            string imagen = imagenComboBox.SelectedValue.ToString();

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Active (IdActive, IdLine, IdZone, DesActive, ImageActive) VALUES (@activo, @idLine, @idZone, @descripcion, @imagen)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@activo", activo);
                command.Parameters.AddWithValue("@idLine", idLine);
                command.Parameters.AddWithValue("@idZone", idZone);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@imagen", imagen);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("El activo se ha introducido con éxito.");
                    insertarButton.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar activo: {ex.Message}");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}