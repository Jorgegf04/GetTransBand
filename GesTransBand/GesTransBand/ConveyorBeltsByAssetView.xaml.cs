using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GesTransBand
{
    public partial class ConveyorBeltsByAssetView : Window
    {
        public ConveyorBeltsByAssetView()
        {
            InitializeComponent();
        }

        private string GetConnectionString()
        {
            return "Server=PCJorge\\PCJORGE4;Database=MiBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
        }

        private void AsignarActivoButton_Click(object sender, RoutedEventArgs e)
        {
            string idText = idTextBox.Text;
            if (int.TryParse(idText, out int idActive))
            {
                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT IdActive, IdLine, IdZone, DesActive, ImageActive 
                        FROM Active 
                        WHERE IdActive = @IdActive";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdActive", idActive);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            idActivoTextBox.Text = reader["IdActive"].ToString();
                            idLineaTextBox.Text = reader["IdLine"].ToString();
                            idZoneTextBox.Text = reader["IdZone"].ToString();
                            desActivoTextBox.Text = reader["DesActive"].ToString();

                            string imagePath = reader["ImageActive"].ToString();
                            activoImage.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));

                            desLineaTextBox.Text = GetLineDescriptionById(int.Parse(idLineaTextBox.Text));
                            desZoneTextBox.Text = GetZoneDescriptionById(int.Parse(idZoneTextBox.Text));
                        }
                        else
                        {
                            MessageBox.Show("El código introducido no se encuentra en Activos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            asignarActivoButton.IsEnabled = false;
                            asignarCintaButton.IsEnabled = false;
                            idTextBox.Clear();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, introduce un ID de activo válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void IdTextBox_TextChanged()
        {
            asignarActivoButton.IsEnabled = !string.IsNullOrWhiteSpace(idTextBox.Text);
            asignarCintaButton.IsEnabled = false;
            idActivoTextBox.Clear();
            idLineaTextBox.Clear();
            idZoneTextBox.Clear();
            desActivoTextBox.Clear();
            desLineaTextBox.Clear();
            desZoneTextBox.Clear();
            activoImage.Source = null;
            IdCintaTextBox_TextChanged();
            idCintaTextBox.Clear();
            cintaPorActivosDataGrid.ItemsSource = null;
        }

        private void IdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IdTextBox_TextChanged();
        }


        private string GetLineDescriptionById(int idLine)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DesLine FROM ProductionLine WHERE IdLine = @IdLine";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdLine", idLine);
                    var result = command.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }

        private string GetZoneDescriptionById(int idZone)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DesZone FROM Zone WHERE IdZone = @IdZone";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdZone", idZone);
                    var result = command.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }

        private void InfoActivoButton_Click(object sender, RoutedEventArgs e)
        {
            ActiveList activeList = new ActiveList();
            activeList.Owner = this;
            activeList.ShowDialog();
        }

        private void InfoCintaButton_Click(object sender, RoutedEventArgs e)
        {
            ListBelt listBelt = new ListBelt();
            listBelt.Owner = this;
            listBelt.ShowDialog();
        }

        private void AsignarCintaButton_Click(object sender, RoutedEventArgs e)
        {
            string idText = idCintaTextBox.Text;
            if (int.TryParse(idText, out int idBelt))
            {
                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT IdBelt, NameBelt 
                        FROM Belt 
                        WHERE IdBelt = @IdBelt";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdBelt", idBelt);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            codigoCintaTextBox.Text = reader["IdBelt"].ToString();
                            desCintaTextBox.Text = reader["NameBelt"].ToString();

                            longCintaTextBox.Text = longitudTextBox.Text;
                            anchoCintaTextBox.Text = anchoTextBox.Text;

                            HabilitarDeshabilitarCerradaTextBlock();
                        }
                        else
                        {
                            MessageBox.Show("El código introducido no se encuentra en Cintas", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            asignarCintaButton.IsEnabled = false;
                            idCintaTextBox.Clear();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, introduce un ID de cinta válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void IdCintaTextBox_TextChanged()
        {
            asignarCintaButton.IsEnabled = !string.IsNullOrWhiteSpace(idCintaTextBox.Text);
            nameActivoTextBox.Clear();
            codigoCintaTextBox.Clear();
            desCintaTextBox.Clear();
            longCintaTextBox.Clear();
            anchoCintaTextBox.Clear();
            longitudTextBox.Clear();
            anchoTextBox.Clear();
            CerradaCheckBox.IsChecked = false;
        }

        private void IdCintaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IdCintaTextBox_TextChanged();
        }

        private void CerradaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            HabilitarDeshabilitarCerradaTextBlock();
        }

        private void CerradaRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            HabilitarDeshabilitarCerradaTextBlock();
        }

        private void HabilitarDeshabilitarCerradaTextBlock()
        {
            if (CerradaCheckBox.IsChecked == true)
            {
                cerradaTextBlock.Text = "Cerrada";
            }
            else
            {
                cerradaTextBlock.Text = string.Empty;
            }
        }

        private void NameActivoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            grabarButton.IsEnabled = !string.IsNullOrWhiteSpace(nameActivoTextBox.Text) && !string.IsNullOrWhiteSpace(codigoCintaTextBox.Text);
        }

        private void GrabarButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    INSERT INTO ConveyorBeltsByAsset (Name, IdActive, IdBelt, Longitude, Wide, Closed)
                    VALUES (@Name, @IdActive, @IdBelt, @Longitude, @Wide, @Closed)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", nameActivoTextBox.Text);
                    command.Parameters.AddWithValue("@IdActive", int.Parse(idActivoTextBox.Text));
                    command.Parameters.AddWithValue("@IdBelt", int.Parse(codigoCintaTextBox.Text));
                    command.Parameters.AddWithValue("@Longitude", int.Parse(longCintaTextBox.Text));
                    command.Parameters.AddWithValue("@Wide", int.Parse(anchoCintaTextBox.Text));
                    command.Parameters.AddWithValue("@Closed", CerradaCheckBox.IsChecked == true ? 1 : 0);

                    command.ExecuteNonQuery();
                }
            }

            LoadConveyorBeltsAssetData();
        }

        private void LoadConveyorBeltsAssetData()
        {
            if (!int.TryParse(idActivoTextBox.Text, out int codigo))
            {
                MessageBox.Show("Por favor, introduce un ID de activo válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM ConveyorBeltsByAsset WHERE IdActive = @codigo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@codigo", codigo);

                    SqlDataReader reader = command.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    cintaPorActivosDataGrid.ItemsSource = dataTable.DefaultView;
                }
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void LimpiarButton_Click(object sender, RoutedEventArgs e)
        {
            idTextBox.Clear();
            IdTextBox_TextChanged();
        }
    }
}
