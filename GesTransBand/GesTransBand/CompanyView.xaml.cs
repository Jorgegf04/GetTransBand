using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace GesTransBand
{
    public partial class CompanyView : Window
    {
        public CompanyView()
        {
            InitializeComponent();
            LoadCompanies();
        }

        private void LoadCompanies()
        {
            // Cargar las compañías desde la base de datos
            List<Company> companies = new List<Company>();

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT IdCompany, Name, Telephone, EmailCompany, Externa, WebCompany FROM Company";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        companies.Add(new Company(
                            (int)reader["IdCompany"],
                            (string)reader["Name"],
                            (string)reader["Telephone"],
                            (string)reader["EmailCompany"],
                            (bool)reader["Externa"],
                            (string)reader["WebCompany"]
                        ));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar compañías: {ex.Message}");
                }
            }

            lvCompanies.ItemsSource = companies;
        }

        private string GetConnectionString()
        {
            return "Server=PCJorge\\PCJORGE4;Database=MiBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
        }

        private void SaveCompany_Click(object sender, RoutedEventArgs e)
        {
            Company company = new Company(
                idCompany: 0,
                name: txtCompanyName.Text,
                telephone: txtCompanyTelephone.Text,
                emailCompany: txtCompanyEmail.Text,
                externa: chkCompanyExterna.IsChecked ?? false,
                webCompany: txtCompanyWeb.Text
            );

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Company (Name, Telephone, EmailCompany, Externa, WebCompany) VALUES (@Name, @Telephone, @EmailCompany, @Externa, @WebCompany)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", company.Name);
                command.Parameters.AddWithValue("@Telephone", company.Telephone);
                command.Parameters.AddWithValue("@EmailCompany", company.EmailCompany);
                command.Parameters.AddWithValue("@Externa", company.Externa);
                command.Parameters.AddWithValue("@WebCompany", company.WebCompany);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Compañía guardada con éxito.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar compañía: {ex.Message}");
                }
            }

            LoadCompanies();
            ClearForm();
        }

        private void DeleteCompany_Click(object sender, RoutedEventArgs e)
        {
            if (lvCompanies.SelectedItem is Company selectedCompany)
            {
                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Company WHERE IdCompany = @IdCompany";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdCompany", selectedCompany.IdCompany);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Compañía eliminada con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar compañía: {ex.Message}");
                    }
                }

                LoadCompanies();
            }
        }

        private void ClearForm()
        {
            txtCompanyName.Clear();
            txtCompanyTelephone.Clear();
            txtCompanyEmail.Clear();
            chkCompanyExterna.IsChecked = false;
            txtCompanyWeb.Clear();
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void lvCompanies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvCompanies.SelectedItem is Company selectedCompany)
            {
                txtCompanyName.Text = selectedCompany.Name;
                txtCompanyTelephone.Text = selectedCompany.Telephone;
                txtCompanyEmail.Text = selectedCompany.EmailCompany;
                chkCompanyExterna.IsChecked = selectedCompany.Externa;
                txtCompanyWeb.Text = selectedCompany.WebCompany;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

    }
}
