using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace GesTransBand
{
    public partial class ContactPersonView : Window
    {
        private ContactPerson selectedContactPerson;
        private string originalContactPersonName;
        private string originalContactPersonSurname;
        private string originalContactPersonTelephone;
        private string originalContactPersonEmail;
        private int originalContactPersonCompanyId;
        public ContactPersonView()
        {
            InitializeComponent();
            LoadCompanies();
            LoadContactPersons();
        }

        private void LoadCompanies()
        {
            List<Company> companies = new List<Company>();

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT IdCompany, Name, Telephone, EmailCompany, Externa, WebCompany FROM Company WHERE Externa = 1";
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
                    MessageBox.Show($"Error al cargar empresas: {ex.Message}");
                }
            }

            companyComboBox.ItemsSource = companies;
        }

        private void LoadContactPersons()
        {
            List<ContactPerson> contactPersons = new List<ContactPerson>();

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT cp.IdContactPerson, cp.IdCompany, cp.Name, cp.Surname, cp.Telephone, cp.Email, c.Name AS CompanyName
            FROM ContactPerson cp
            JOIN Company c ON cp.IdCompany = c.IdCompany";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        contactPersons.Add(new ContactPerson(
                            (int)reader["IdContactPerson"],
                            (int)reader["IdCompany"],
                            (string)reader["Name"],
                            (string)reader["Surname"],
                            (string)reader["Telephone"],
                            (string)reader["Email"],
                            (string)reader["CompanyName"]
                        ));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar personas de contacto: {ex.Message}");
                }
            }

            lvContactPerson.ItemsSource = contactPersons;
        }

        private string GetConnectionString()
        {
            return "Server=PCJorge\\PCJORGE4;Database=MiBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
        }

        private void SaveContactPerson_Click(object sender, RoutedEventArgs e)
        {
            if (selectedContactPerson != null && companyComboBox.SelectedItem is Company selectedCompany)
            {
                selectedContactPerson.IdCompany = selectedCompany.IdCompany;
                selectedContactPerson.Name = nameTextBox.Text;
                selectedContactPerson.Surname = surnameTextBox.Text;
                selectedContactPerson.Telephone = telephoneTextBox.Text;
                selectedContactPerson.Email = emailTextBox.Text;
                selectedContactPerson.CompanyName = selectedCompany.Name;

                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE [ContactPerson] SET IdCompany = @IdCompany, Name = @Name, Surname = @Surname, Telephone = @Telephone, Email = @Email WHERE IdContactPerson = @IdContactPerson";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdContactPerson", selectedContactPerson.IdContactPerson);
                    command.Parameters.AddWithValue("@IdCompany", selectedContactPerson.IdCompany);
                    command.Parameters.AddWithValue("@Name", selectedContactPerson.Name);
                    command.Parameters.AddWithValue("@Surname", selectedContactPerson.Surname);
                    command.Parameters.AddWithValue("@Telephone", selectedContactPerson.Telephone);
                    command.Parameters.AddWithValue("@Email", selectedContactPerson.Email);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Contacto actualizado con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar el contacto: {ex.Message}");
                    }
                }

                LoadContactPersons();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Seleccione un contacto para actualizar.");
            }
        }

        private void DeleteContactPerson_Click(object sender, RoutedEventArgs e)
        {
            if (lvContactPerson.SelectedItem is ContactPerson selectedContactPerson)
            {
                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM [ContactPerson] WHERE IdContactPerson = @IdContactPerson";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdAssembler", selectedContactPerson.IdContactPerson);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Contacto eliminado con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el contacto: {ex.Message}");
                    }
                }

                LoadContactPersons();
            }
        }

        private void ClearForm()
        {
            nameTextBox.Clear();
            surnameTextBox.Clear();
            telephoneTextBox.Clear();
            emailTextBox.Clear();
            companyComboBox.SelectedItem = -1;
            lvContactPerson.SelectedItem = null;
            saveButton.IsEnabled = false;
            deleteButton.IsEnabled = false;
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void LvAssembler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvContactPerson.SelectedItem is ContactPerson contactPerson)
            {
                selectedContactPerson = contactPerson; // Asignar el contacto seleccionado
                nameTextBox.Text = selectedContactPerson.Name;
                surnameTextBox.Text = selectedContactPerson.Surname;
                telephoneTextBox.Text = selectedContactPerson.Telephone;
                emailTextBox.Text = selectedContactPerson.Email;
                companyComboBox.SelectedValue = selectedContactPerson.IdCompany;

                originalContactPersonName = selectedContactPerson.Name;
                originalContactPersonSurname = selectedContactPerson.Surname;
                originalContactPersonTelephone = selectedContactPerson.Telephone;
                originalContactPersonEmail = selectedContactPerson.Email;
                originalContactPersonCompanyId = selectedContactPerson.IdCompany;

                saveButton.IsEnabled = false;
                deleteButton.IsEnabled = true;
                nuevoButton.IsEnabled = false;
            }
            else
            {
                ClearForm();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            if (companyComboBox.SelectedItem is Company selectedCompany && selectedContactPerson != null)
            {
                ContactPerson contactPerson = new ContactPerson(
                    idContactPerson: selectedContactPerson.IdContactPerson,
                    idCompany: selectedCompany.IdCompany,
                    name: nameTextBox.Text,
                    surname: surnameTextBox.Text,
                    telephone: telephoneTextBox.Text,
                    email: emailTextBox.Text,
                    companyName: selectedCompany.Name
                );

                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO [ContactPerson] (IdCompany, Name, Surname, Telephone, Email) VALUES (@IdCompany, @Name, @Surname, @Telephone, @Email)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdCompany", contactPerson.IdCompany);
                    command.Parameters.AddWithValue("@Name", contactPerson.Name);
                    command.Parameters.AddWithValue("@Surname", contactPerson.Surname);
                    command.Parameters.AddWithValue("@Telephone", contactPerson.Telephone);
                    command.Parameters.AddWithValue("@Email", contactPerson.Email);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Contacto creado con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al crear el contacto: {ex.Message}");
                    }
                }
                saveButton.IsEnabled = false;
                LoadContactPersons();
                ClearForm();
            }
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableSaveButton();
        }

        private void SurnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableSaveButton();
        }

        private void TelephoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableSaveButton();
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableSaveButton();
        }

        private void CompanyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableSaveButton();
        }

        private void EnableSaveButton()
        {
            bool isChanged = nameTextBox.Text != originalContactPersonName ||
                             surnameTextBox.Text != originalContactPersonSurname ||
                             telephoneTextBox.Text != originalContactPersonTelephone ||
                             emailTextBox.Text != originalContactPersonEmail ||
                             (companyComboBox.SelectedItem != null && (int)companyComboBox.SelectedValue != originalContactPersonCompanyId);

            saveButton.IsEnabled = isChanged;

            nuevoButton.IsEnabled = !string.IsNullOrEmpty(nameTextBox.Text) &&
                                    !string.IsNullOrEmpty(surnameTextBox.Text) &&
                                    !string.IsNullOrEmpty(telephoneTextBox.Text) &&
                                    !string.IsNullOrEmpty(emailTextBox.Text) &&
                                    companyComboBox.SelectedItem != null;
        }
    }
}