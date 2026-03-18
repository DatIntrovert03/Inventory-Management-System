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
using Inventory_Management_System.ViewModels;

namespace Inventory_Management_System.View
{
    /// <summary>
    /// Interaction logic for ItemsView.xaml
    /// </summary>
    public partial class ItemsView : Window
    {
        ItemsViewModel viewModel;
        public ItemsView()
        {
            InitializeComponent();
            viewModel = new ItemsViewModel();
            this.DataContext = viewModel;
        }

       
    }
}
