using Inventory_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Inventory_Management_System.Commands;


namespace Inventory_Management_System.ViewModels
{
    public class SuppliersViewModel : BaseViewModel
    {
        //why did we make supplier an observable collection? because we want to be able to add, remove,
        //and update suppliers in the collection and have those changes automatically reflected in the UI.
        //ObservableCollection provides notifications when items are added, removed, or when the whole list is refreshed,
        //which allows the UI to stay in sync with the underlying data.
        private ObservableCollection<Supplier> suppliers;
        public ObservableCollection<Supplier> Suppliers
        {
            get { return suppliers; }
            set
            {
                suppliers = value;
                OnpropertyChanged(nameof(Suppliers));
            }
        }

        private Supplier selectedSupplier;
        public Supplier SelectedSupplier
        {
            get { return selectedSupplier; }
            set
            {
                selectedSupplier = value;
                if (selectedSupplier != null)
                {
                    // populate edit fields when a supplier is selected
                    Name = selectedSupplier.Name;
                    Phone = selectedSupplier.Phone;
                    Address = selectedSupplier.Address;
                }
                OnpropertyChanged(nameof(SelectedSupplier));
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnpropertyChanged(nameof(Name));
            }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnpropertyChanged(nameof(Phone));
            }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set
             {
                address = value;
                OnpropertyChanged(nameof(Address));
            }
        }
        public ICommand SaveCommand { get; }
        public ICommand UpdateCommand { get; }
        public SuppliersViewModel()
        {
            Name = string.Empty;
            Phone = string.Empty;
            Address = string.Empty;
            SaveCommand = new RelayCommand(SaveSupplier, CanSaveSupplier);
            UpdateCommand = new RelayCommand(UpdateSupplier, CanUpdateSupplier);
            LoadSuppliers();
        }
        private bool CanSaveSupplier(object obj)
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Phone) && !string.IsNullOrEmpty(Address);
        }
        private void SaveSupplier(object obj)
        {
            Supplier newSupplier = new Supplier
            {
                Name = Name,
                Phone = Phone,
                Address = Address
            };
            InventoryDBContext db = new InventoryDBContext();
            db.Suppliers.Add(newSupplier);
            db.SaveChanges();
            ClearFields();
            LoadSuppliers();
        }
        public void UpdateSupplier(object obj)
        {

            InventoryDBContext db = new InventoryDBContext();
            var supplierToUpdate = db.Suppliers.Find(SelectedSupplier.SupplierId);
            if (supplierToUpdate == null)
            {
                return;
            }
            supplierToUpdate.Name = Name;
            supplierToUpdate.Phone = Phone;
            supplierToUpdate.Address = Address;
            db.Entry(supplierToUpdate).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            ClearFields();
            LoadSuppliers();
        }
        private void LoadSuppliers()
        {
            using (var db = new InventoryDBContext())
            {
                Suppliers = new ObservableCollection<Supplier>(db.Suppliers.ToList());
            }
        }
        private bool CanUpdateSupplier(object obj)
        {
            return SelectedSupplier != null && !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Phone) && !string.IsNullOrEmpty(Address);
        }
        private void ClearFields()
        {
            Name = string.Empty;
            Phone = string.Empty;
            Address = string.Empty;
        }       
    }
}
