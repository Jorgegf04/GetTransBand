using System;
using System.Windows;

namespace GesTransBand
{
    public partial class NewProduct : Window
    {
        public string ProductDescription { get; private set; }
        public DateTime ProductDate { get; private set; }
        public bool IsSaved { get; private set; }

        public NewProduct()
        {
            InitializeComponent();
            IsSaved = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ProductDescription = txtDescription.Text;
            ProductDate = dpFechaLote.SelectedDate ?? DateTime.Now;
            IsSaved = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
