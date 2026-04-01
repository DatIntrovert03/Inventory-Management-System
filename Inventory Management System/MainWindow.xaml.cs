using Inventory_Management_System.View;
using Inventory_Management_System.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inventory_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnItems_Click(object sender, RoutedEventArgs e)
        {
            ItemsView view=new ItemsView();
            view.ShowDialog();
        }

        private void BtnSuppliers_Click(object sender, RoutedEventArgs e)
        {
            SuppliersView view=new SuppliersView();
            view.ShowDialog();
        }
    }
}