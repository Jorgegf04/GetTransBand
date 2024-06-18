using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GesTransBand
{
    public partial class ActiveList : Window
    {
        public ActiveList(List<ActiveDTO> actives)
        {
            InitializeComponent();
            ActivesDataGrid.ItemsSource = actives;
            UpdateButtonsState();
        }
        public ActiveList() : base()
        {
            InitializeComponent();
            ActivesDataGrid.ItemsSource = Active.GetActives();
            UpdateButtonsState();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActivesDataGrid.SelectedItem is ActiveDTO selectedActive)
            {
                EditActiveWindow editWindow = new EditActiveWindow(selectedActive);
                if (editWindow.ShowDialog() == true)
                {
                    ActivesDataGrid.ItemsSource = null;
                    ActivesDataGrid.ItemsSource = Active.GetActives();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un elemento para editar.", "Editar",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActivesDataGrid.SelectedItem is ActiveDTO selectedActive)
            {

                MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar el elemento seleccionado?", "Eliminar",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    Active.DeleteActive(selectedActive.IdActive);

                    ActivesDataGrid.ItemsSource = null;
                    ActivesDataGrid.ItemsSource = Active.GetActives();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un elemento para eliminar.", "Eliminar",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ActivesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool isSelected = ActivesDataGrid.SelectedItem != null;
            editButton.IsEnabled = isSelected;
            deleteButton.IsEnabled = isSelected;
        }

        private void CleanButton_Click(object sender, RoutedEventArgs e)
        {
            ActivesDataGrid.SelectedItem = null;
            UpdateButtonsState();
        }
    }
}
