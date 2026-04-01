using Inventory_Management_System.ViewModels;
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

namespace Inventory_Management_System.Views
{
    /// <summary>
    /// Interaction logic for SuppliersView.xaml
    /// </summary>
    public partial class SuppliersView : Window
    {
        SuppliersViewModel viewModel;
        public SuppliersView()
        {
            InitializeComponent();
            viewModel = new SuppliersViewModel();
            this.DataContext = viewModel;   //allows databinding to work by setting the DataContext of the view to the view model.
                                            //This means that any bindings in the XAML will look for properties and commands in the SuppliersViewModel.
        }
    }
}
