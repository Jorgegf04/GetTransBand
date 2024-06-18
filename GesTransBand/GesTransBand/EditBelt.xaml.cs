using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public partial class EditBelt : Window
    {
        private Belt cinta;
        public EditBelt(Belt cinta)
        {
            InitializeComponent();
            this.cinta = cinta;
            IdBeltTextBox.Text = cinta.IdBelt.ToString();
            NameBeltTextBox.Text = cinta.NameBelt;
            DataSheetTextBox.Text = cinta.DataSheet;
            CertificateTextBox.Text = cinta.Certificate;
            guardarButton.IsEnabled = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int idCinta = int.Parse(IdBeltTextBox.Text);
            string nombreCinta = NameBeltTextBox.Text;
            string fichaTecnica = DataSheetTextBox.Text;
            string Certificado = CertificateTextBox.Text;

            try
            {
                cinta = new Belt(idCinta, nombreCinta, fichaTecnica, Certificado);
                Belt.UpdateBelt(cinta);
                MessageBox.Show("La cinta se ha introducido con éxito.");
                guardarButton.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guarda la cinta: {ex.Message}");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            guardarButton.IsEnabled = true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
