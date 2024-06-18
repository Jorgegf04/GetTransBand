using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace GesTransBand
{
    public partial class MainWindow : Window
    {
        public List<Active> Activos { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadBeltAssignments();
            List<ActiveDTO> actives = Active.GetActives();
        }

        private void ExitAplication_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListActive_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ActiveList activeList = new ActiveList();
            activeList.Owner = this;
            activeList.ShowDialog();
        }

        private void NuevoActivo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            NewActive newActive = new NewActive();
            newActive.Owner = this;
            newActive.ShowDialog();
        }

        private void NuevaCinta_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            NewBelt newBelt = new NewBelt();
            newBelt.Owner = this;
            newBelt.ShowDialog();
        }

        private void ListaCintas_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ListBelt cintas= new ListBelt();
            cintas.Owner = this;
            cintas.ShowDialog();
        }

        private void ManageUsers_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UserView userView = new UserView();
            userView.Owner = this;
            userView.ShowDialog();
        }

        private void ManageContactPersons_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ContactPersonView contactPersonView = new ContactPersonView();
            contactPersonView.Owner = this;
            contactPersonView.ShowDialog();
        }

        private void ManageProducts_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ProductView productView = new ProductView();
            productView.Owner = this;
            productView.ShowDialog();
        }

        private void ManageCompanies_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CompanyView companyView = new CompanyView();
            companyView.Owner = this;
            companyView.ShowDialog();
        }

        private void LoadBeltAssignments()
        {
            List<Belt> belts = Belt.GetBelts();

            cbLine1FormadoBelt.ItemsSource = belts;
            cbLine1FormadoBelt.DisplayMemberPath = "NameBelt";
            cbLine1FormadoBelt.SelectedValuePath = "IdBelt";

            cbLine1EntreTunelesBelt.ItemsSource = belts;
            cbLine1EntreTunelesBelt.DisplayMemberPath = "NameBelt";
            cbLine1EntreTunelesBelt.SelectedValuePath = "IdBelt";

            cbLine1EnvasadoBelt.ItemsSource = belts;
            cbLine1EnvasadoBelt.DisplayMemberPath = "NameBelt";
            cbLine1EnvasadoBelt.SelectedValuePath = "IdBelt";

            cbLine2FormadoBelt.ItemsSource = belts;
            cbLine2FormadoBelt.DisplayMemberPath = "NameBelt";
            cbLine2FormadoBelt.SelectedValuePath = "IdBelt";

            cbLine2EntreTunelesBelt.ItemsSource = belts;
            cbLine2EntreTunelesBelt.DisplayMemberPath = "NameBelt";
            cbLine2EntreTunelesBelt.SelectedValuePath = "IdBelt";

            cbLine2EnvasadoBelt.ItemsSource = belts;
            cbLine2EnvasadoBelt.DisplayMemberPath = "NameBelt";
            cbLine2EnvasadoBelt.SelectedValuePath = "IdBelt";
        }

        private void ManageAssembler_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AssemblerView assemblerView = new AssemblerView();
            assemblerView.Owner = this;
            assemblerView.ShowDialog();
        }

        private void CintasPorActivo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ConveyorBeltsByAssetView cintasPorActivo = new ConveyorBeltsByAssetView();
            cintasPorActivo.Owner=this;
            cintasPorActivo.ShowDialog();
        }

        private void TreeView_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TreeViewWindow treeView = new TreeViewWindow();
            treeView.Owner = this;
            treeView.ShowDialog();
        }
    }


}


