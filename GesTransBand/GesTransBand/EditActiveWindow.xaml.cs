using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace GesTransBand
{
    public partial class EditActiveWindow : Window
    {
        private ActiveDTO active;

        public EditActiveWindow(ActiveDTO active)
        {
            InitializeComponent();
            this.active = active;
            IdActiveTextBox.Text = active.IdActive.ToString();
            DesLineTextBox.Text = active.DesLine;
            DesZoneTextBox.Text = active.DesZone;
            DesActiveTextBox.Text = active.DesActive;
            ImageActiveTextBox.Text = active.ImageActive;

            LoadLineaListBox();
            LoadZonaListBox();
        }

        private void LoadLineaListBox()
        {
            string connectionString = "Server=PCJorge\\PCJORGE4;Database=MiBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
            string query = "SELECT IdLine, DesLine FROM ProductionLine";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable lineTable = new DataTable();
                adapter.Fill(lineTable);
                lineaListBox.ItemsSource = lineTable.DefaultView;
            }
        }

        private void LoadZonaListBox()
        {
            string connectionString = "Server=PCJorge\\PCJORGE4;Database=MiBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
            string query = "SELECT IdZone, DesZone FROM Zone";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable zoneTable = new DataTable();
                adapter.Fill(zoneTable);
                zonaListBox.ItemsSource = zoneTable.DefaultView;
            }
        }


        private void LineaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lineaListBox.SelectedItem != null)
            {
                DataRowView row = (DataRowView)lineaListBox.SelectedItem;
                DesLineTextBox.Text = row["DesLine"].ToString();
            }
        }

        private void ZonaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (zonaListBox.SelectedItem != null)
            {
                DataRowView row = (DataRowView)zonaListBox.SelectedItem;
                DesZoneTextBox.Text = row["DesZone"].ToString();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            guardarButton.IsEnabled = !string.IsNullOrWhiteSpace(DesActiveTextBox.Text) ||
                                      !string.IsNullOrWhiteSpace(ImageActiveTextBox.Text);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            active.DesLine = DesLineTextBox.Text;
            active.DesZone = DesZoneTextBox.Text;
            active.DesActive = DesActiveTextBox.Text;
            active.ImageActive = ImageActiveTextBox.Text;

            Active.UpdateActive(active);

            MessageBox.Show("Cambios guardados.", "Guardar", MessageBoxButton.OK, MessageBoxImage.Information);
            guardarButton.IsEnabled = false;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}

