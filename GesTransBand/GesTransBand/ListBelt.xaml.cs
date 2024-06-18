using System;
using System.Collections.Generic;
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
{
    public partial class ListBelt : Window
    {

        public ListBelt()
        {
            InitializeComponent();
            listadoCintasDataGrid.ItemsSource = Belt.GetBelts();
            UpdateButtonsState();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void EliminarCinta_Click(object sender, RoutedEventArgs e)
        {
            if (listadoCintasDataGrid.SelectedItem is Belt cinta)
            {
                MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar el elemento seleccionado?",
                                                            "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    Belt.DeleteBelt(cinta.IdBelt);
                    listadoCintasDataGrid.ItemsSource = null;
                    listadoCintasDataGrid.ItemsSource = Belt.GetBelts();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un elemento para eliminar.",
                                    "Eliminar", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void EditarCinta_Click(object sender, RoutedEventArgs e)
        {
            if (listadoCintasDataGrid.SelectedItem is Belt cinta)
            {
                EditBelt editBelt= new EditBelt(cinta);
                if (editBelt.ShowDialog() == true)
                {
                    listadoCintasDataGrid.ItemsSource = null;
                    listadoCintasDataGrid.ItemsSource = Belt.GetBelts();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un elemento para editar.", "Editar",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ActivesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool isSelected = listadoCintasDataGrid.SelectedItem != null;
            editButton.IsEnabled = isSelected;
            deleteButton.IsEnabled = isSelected;
        }
        private void CleanButton_Click(object sender, RoutedEventArgs e)
        {
            listadoCintasDataGrid.SelectedItem = null;
            UpdateButtonsState();
        }
    }
}
