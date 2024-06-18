using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace GesTransBand
{
    public partial class UserView : Window
    {
        private User selectedUser;
        private string originalUserName;
        private string originalUserSurname;
        private string originalUserTelephone;
        private string originalUserEmail;
        private int originalUserCompanyId;


        public UserView()
        {
            InitializeComponent();
            LoadCompanies();
            LoadUsers();
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

            cbUserCompany.ItemsSource = companies;
        }

        private void LoadUsers()
        {
            List<User> users = new List<User>();

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT u.IdUser, u.IdCompany, u.Name, u.Surname, u.Telephone, u.Email, c.Name AS CompanyName " +
                               "FROM [User] u " +
                               "JOIN Company c ON u.IdCompany = c.IdCompany";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        users.Add(new User(
                            (int)reader["IdUser"],
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

            lvUsers.ItemsSource = users;
        }


        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser != null && cbUserCompany.SelectedItem is Company selectedCompany)
            {
                selectedUser.IdCompany = selectedCompany.IdCompany;
                selectedUser.Name = txtUserName.Text;
                selectedUser.Surname = txtUserSurname.Text;
                selectedUser.Telephone = txtUserTelephone.Text;
                selectedUser.Email = txtUserEmail.Text;
                selectedUser.CompanyName = selectedCompany.Name;

                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE [User] SET IdCompany = @IdCompany, Name = @Name, Surname = @Surname, Telephone = @Telephone, Email = @Email WHERE IdUser = @IdUser";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdUser", selectedUser.IdUser);
                    command.Parameters.AddWithValue("@IdCompany", selectedUser.IdCompany);
                    command.Parameters.AddWithValue("@Name", selectedUser.Name);
                    command.Parameters.AddWithValue("@Surname", selectedUser.Surname);
                    command.Parameters.AddWithValue("@Telephone", selectedUser.Telephone);
                    command.Parameters.AddWithValue("@Email", selectedUser.Email);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Usuario actualizado con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar usuario: {ex.Message}");
                    }
                }

                LoadUsers();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para actualizar.");
            }
        }


        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (lvUsers.SelectedItem is User selectedUser)
            {
                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM [User] WHERE IdUser = @IdUser";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdUser", selectedUser.IdUser);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Usuario eliminado con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar usuario: {ex.Message}");
                    }
                }

                LoadUsers();
            }
        }

        private void ClearForm()
        {
            txtUserName.Clear();
            txtUserSurname.Clear();
            txtUserTelephone.Clear();
            txtUserEmail.Clear();
            cbUserCompany.SelectedIndex = -1;
            lvUsers.SelectedItem = null;
            selectedUser = null; // Reiniciar selectedUser
            saveButton.IsEnabled = false;
            deleteButton.IsEnabled = false;
            nuevoButton.IsEnabled = false;
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }


        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvUsers.SelectedItem is User user)
            {
                selectedUser = user; // Asignar el usuario seleccionado
                txtUserName.Text = selectedUser.Name;
                txtUserSurname.Text = selectedUser.Surname;
                txtUserTelephone.Text = selectedUser.Telephone;
                txtUserEmail.Text = selectedUser.Email;
                cbUserCompany.SelectedValue = selectedUser.IdCompany;

                originalUserName = selectedUser.Name;
                originalUserSurname = selectedUser.Surname;
                originalUserTelephone = selectedUser.Telephone;
                originalUserEmail = selectedUser.Email;
                originalUserCompanyId = selectedUser.IdCompany;

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
        {
            return "Server=PCJorge\\PCJORGE4;Database=MiBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableSaveButton();
        }

        private void txtUserSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableSaveButton();
        }

        private void txtUserTelephone_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableSaveButton();
        }

        private void txtUserEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableSaveButton();
        }

        private void cbUserCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableSaveButton();
        }

        private void EnableSaveButton()
        {
            bool isChanged = txtUserName.Text != originalUserName ||
                             txtUserSurname.Text != originalUserSurname ||
                             txtUserTelephone.Text != originalUserTelephone ||
                             txtUserEmail.Text != originalUserEmail ||
                             (cbUserCompany.SelectedItem != null && (int)cbUserCompany.SelectedValue != originalUserCompanyId);

            saveButton.IsEnabled = isChanged;

            nuevoButton.IsEnabled = !string.IsNullOrEmpty(txtUserName.Text) &&
                                    !string.IsNullOrEmpty(txtUserSurname.Text) &&
                                    !string.IsNullOrEmpty(txtUserTelephone.Text) &&
                                    !string.IsNullOrEmpty(txtUserEmail.Text) &&
                                    cbUserCompany.SelectedItem != null;
        }


        private void NuevoUser_Click(object sender, RoutedEventArgs e)
        {
            if (cbUserCompany.SelectedItem is Company selectedCompany)
            {
                User user = new User(
                    idUser: 0, 
                    idCompany: selectedCompany.IdCompany,
                    name: txtUserName.Text,
                    surname: txtUserSurname.Text,
                    telephone: txtUserTelephone.Text,
                    email: txtUserEmail.Text,
                    companyName: selectedCompany.Name
                );

                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO [User] (IdCompany, Name, Surname, Telephone, Email) VALUES (@IdCompany, @Name, @Surname, @Telephone, @Email)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdCompany", user.IdCompany);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Surname", user.Surname);
                    command.Parameters.AddWithValue("@Telephone", user.Telephone);
                    command.Parameters.AddWithValue("@Email", user.Email);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Usuario creado con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al crear usuario: {ex.Message}");
                    }
                }
                saveButton.IsEnabled = false;
                LoadUsers();
                ClearForm();
            }
        }

    }
}