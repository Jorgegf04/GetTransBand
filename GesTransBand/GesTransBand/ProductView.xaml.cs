using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace GesTransBand
{
    public partial class ProductView : Window
    {
        private List<Product> line1Products;
        private List<Product> line2Products;

        public ProductView()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            line1Products = new List<Product>();
            line2Products = new List<Product>();

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT IdProduct, IdLine, DesProduct, FechaLote FROM Product";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product(
                            (int)reader["IdProduct"],
                            (int)reader["IdLine"],
                            (string)reader["DesProduct"],
                            (DateTime)reader["FechaLote"]
                        );

                        if (product.IdLine == 1)
                        {
                            line1Products.Add(product);
                        }
                        else if (product.IdLine == 2)
                        {
                            line2Products.Add(product);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar productos: {ex.Message}");
                }
            }

            lvLine1Products.ItemsSource = line1Products;
            lvLine2Products.ItemsSource = line2Products;
        }

        private string GetConnectionString()
        {
            return "Server=PCJorge\\PCJORGE4;Database=MiBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
        }

        private void AddLine1Product_Click(object sender, RoutedEventArgs e)
        {
            var newProductWindow = new NewProduct();
            newProductWindow.ShowDialog();

            if (newProductWindow.IsSaved)
            {
                Product newProduct = new Product(0, 1, newProductWindow.ProductDescription, newProductWindow.ProductDate);
                line1Products.Add(newProduct);
                lvLine1Products.Items.Refresh();
                lvLine1Products.SelectedItem = newProduct;
            }
        }

        private void SaveLine1Product_Click(object sender, RoutedEventArgs e)
        {
            if (lvLine1Products.SelectedItem is Product selectedProduct)
            {
                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = selectedProduct.IdProduct == 0 ?
                        "INSERT INTO Product (IdLine, DesProduct, FechaLote) VALUES (@IdLine, @DesProduct, @FechaLote)" :
                        "UPDATE Product SET DesProduct = @DesProduct, FechaLote = @FechaLote WHERE IdProduct = @IdProduct";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdLine", selectedProduct.IdLine);
                    command.Parameters.AddWithValue("@DesProduct", selectedProduct.DesProduct);
                    command.Parameters.AddWithValue("@FechaLote", selectedProduct.FechaLote);

                    if (selectedProduct.IdProduct != 0)
                    {
                        command.Parameters.AddWithValue("@IdProduct", selectedProduct.IdProduct);
                    }

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Producto guardado con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar producto: {ex.Message}");
                    }
                }

                LoadProducts();
            }
        }

        private void DeleteLine1Product_Click(object sender, RoutedEventArgs e)
        {
            if (lvLine1Products.SelectedItem is Product selectedProduct && selectedProduct.IdProduct != 0)
            {
                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Product WHERE IdProduct = @IdProduct";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdProduct", selectedProduct.IdProduct);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Producto eliminado con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar producto: {ex.Message}");
                    }
                }

                LoadProducts();
            }
        }

        private void AddLine2Product_Click(object sender, RoutedEventArgs e)
        {
            var newProductWindow = new NewProduct();
            newProductWindow.ShowDialog();

            if (newProductWindow.IsSaved)
            {
                Product newProduct = new Product(0, 2, newProductWindow.ProductDescription, newProductWindow.ProductDate);
                line2Products.Add(newProduct);
                lvLine2Products.Items.Refresh();
                lvLine2Products.SelectedItem = newProduct;
            }
        }

        private void SaveLine2Product_Click(object sender, RoutedEventArgs e)
        {
            if (lvLine2Products.SelectedItem is Product selectedProduct)
            {
                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = selectedProduct.IdProduct == 0 ?
                        "INSERT INTO Product (IdLine, DesProduct, FechaLote) VALUES (@IdLine, @DesProduct, @FechaLote)" :
                        "UPDATE Product SET DesProduct = @DesProduct, FechaLote = @FechaLote WHERE IdProduct = @IdProduct";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdLine", selectedProduct.IdLine);
                    command.Parameters.AddWithValue("@DesProduct", selectedProduct.DesProduct);
                    command.Parameters.AddWithValue("@FechaLote", selectedProduct.FechaLote);

                    if (selectedProduct.IdProduct != 0)
                    {
                        command.Parameters.AddWithValue("@IdProduct", selectedProduct.IdProduct);
                    }

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Producto guardado con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar producto: {ex.Message}");
                    }
                }

                LoadProducts();
            }
        }

        private void DeleteLine2Product_Click(object sender, RoutedEventArgs e)
        {
            if (lvLine2Products.SelectedItem is Product selectedProduct && selectedProduct.IdProduct != 0)
            {
                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Product WHERE IdProduct = @IdProduct";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdProduct", selectedProduct.IdProduct);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Producto eliminado con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar producto: {ex.Message}");
                    }
                }

                LoadProducts();
            }
        }

        private void lvLine1Products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvLine1Products.SelectedItem is Product selectedProduct)
            {
                txtLine1Description.Text = selectedProduct.DesProduct;
                dpLine1FechaLote.SelectedDate = selectedProduct.FechaLote;
            }
        }

        private void lvLine2Products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvLine2Products.SelectedItem is Product selectedProduct)
            {
                txtLine2Description.Text = selectedProduct.DesProduct;
                dpLine2FechaLote.SelectedDate = selectedProduct.FechaLote;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
