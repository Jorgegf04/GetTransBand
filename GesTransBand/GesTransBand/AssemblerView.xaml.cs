using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace GesTransBand
{
    public partial class AssemblerView : Window
    {
        private Assembler selectedAssembler;
        private string originalAssemblerName;
        private string originalAssemblerSurname;
        private string originalAssemblerTelephone;
        private string originalAssemblerEmail;
        private int originalAssemblerCompanyId;

        public AssemblerView()
        {
            InitializeComponent();
            LoadCompanies();
            LoadAssemblers();
        }

        private void LoadCompanies()
        {
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

            companyComboBox.ItemsSource = companies;
        }

        private void LoadAssemblers()
        {
            List<Assembler> assembler= new List<Assembler>();

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT u.IdAssembler, u.IdCompany, u.Name, u.Surname, u.Telephone, u.Email, c.Name AS CompanyName " +
                               "FROM [Assembler] u " +
                               "JOIN Company c ON u.IdCompany = c.IdCompany";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        assembler.Add(new Assembler(
                            (int)reader["IdAssembler"],
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
                    MessageBox.Show($"Error al cargar usuarios: {ex.Message}");
                }
            }

            lvAssembler.ItemsSource = assembler;
        }


        private void SaveAssembler_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAssembler != null && companyComboBox.SelectedItem is Company selectedCompany)
            {
                selectedAssembler.IdCompany = selectedCompany.IdCompany;
                selectedAssembler.Name = nameTextBox.Text;
                selectedAssembler.Surname = surnameTextBox.Text;
                selectedAssembler.Telephone = telephoneTextBox.Text;
                selectedAssembler.Email = emailTextBox.Text;
                selectedAssembler.CompanyName = selectedCompany.Name;

                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE [Assembler] SET IdCompany = @IdCompany, Name = @Name, Surname = @Surname, Telephone = @Telephone, Email = @Email WHERE IdAssembler = @IdAssembler";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdAssembler", selectedAssembler.IdAssembler);
                    command.Parameters.AddWithValue("@IdCompany", selectedAssembler.IdCompany);
                    command.Parameters.AddWithValue("@Name", selectedAssembler.Name);
                    command.Parameters.AddWithValue("@Surname", selectedAssembler.Surname);
                    command.Parameters.AddWithValue("@Telephone", selectedAssembler.Telephone);
                    command.Parameters.AddWithValue("@Email", selectedAssembler.Email);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Montador actualizado con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar el montador: {ex.Message}");
                    }
                }

                LoadAssemblers();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Seleccione un montador para actualizar.");
            }
        }

        private void DeleteAssembler_Click(object sender, RoutedEventArgs e)
        {
            if (lvAssembler.SelectedItem is Assembler selectedAssembler)
            {
                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM [Assembler] WHERE IdAssembler = @IdAssembler";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdAssembler", selectedAssembler.IdAssembler);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Montador eliminado con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el montador: {ex.Message}");
                    }
                }

                LoadAssemblers();
            }
        }

        private void ClearForm()
        {
            nameTextBox.Clear();
            surnameTextBox.Clear();
            telephoneTextBox.Clear();
            emailTextBox.Clear();
            companyComboBox.SelectedIndex = -1;
            lvAssembler.SelectedItem = null;
            selectedAssembler = null; // Reiniciar selectedAssembler
            saveButton.IsEnabled = false;
            deleteButton.IsEnabled = false;
            nuevoButton.IsEnabled = false;
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void LvAssembler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvAssembler.SelectedItem is Assembler assembler)
            {
                selectedAssembler = assembler; // Asignar el montador seleccionado
                nameTextBox.Text = selectedAssembler.Name;
                surnameTextBox.Text = selectedAssembler.Surname;
                telephoneTextBox.Text = selectedAssembler.Telephone;
                emailTextBox.Text = selectedAssembler.Email;
                companyComboBox.SelectedValue = selectedAssembler.IdCompany;

                originalAssemblerName = selectedAssembler.Name;
                originalAssemblerSurname = selectedAssembler.Surname;
                originalAssemblerTelephone = selectedAssembler.Telephone;
                originalAssemblerEmail = selectedAssembler.Email;
                originalAssemblerCompanyId = selectedAssembler.IdCompany;

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

        private string GetConnectionString()
            => "Server=PCJorge\\PCJORGE4;Database=MiBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";

        private void NuevoAssembler_Click(object sender, RoutedEventArgs e)
        {
            if (companyComboBox.SelectedItem is Company selectedCompany && selectedAssembler != null)
            {
                Assembler assembler = new Assembler(
                    idAssembler: selectedAssembler.IdAssembler,
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
                    string query = "INSERT INTO [Assembler] (IdCompany, Name, Surname, Telephone, Email) VALUES (@IdCompany, @Name, @Surname, @Telephone, @Email)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdCompany", assembler.IdCompany);
                    command.Parameters.AddWithValue("@Name", assembler.Name);
                    command.Parameters.AddWithValue("@Surname", assembler.Surname);
                    command.Parameters.AddWithValue("@Telephone", assembler.Telephone);
                    command.Parameters.AddWithValue("@Email", assembler.Email);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Montador creado con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al crear el montador: {ex.Message}");
                    }
                }
                saveButton.IsEnabled = false;
                LoadAssemblers();
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
            bool isChanged = nameTextBox.Text != originalAssemblerName ||
                             surnameTextBox.Text != originalAssemblerSurname ||
                             telephoneTextBox.Text != originalAssemblerTelephone ||
                             emailTextBox.Text != originalAssemblerEmail ||
                             (companyComboBox.SelectedItem != null && (int)companyComboBox.SelectedValue != originalAssemblerCompanyId);

            saveButton.IsEnabled = isChanged;

            nuevoButton.IsEnabled = !string.IsNullOrEmpty(nameTextBox.Text) &&
                                    !string.IsNullOrEmpty(surnameTextBox.Text) &&
                                    !string.IsNullOrEmpty(telephoneTextBox.Text) &&
                                    !string.IsNullOrEmpty(emailTextBox.Text) &&
                                    companyComboBox.SelectedItem != null;
        }
    }
}