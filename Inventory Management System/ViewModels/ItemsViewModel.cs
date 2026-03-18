using Inventory_Management_System.Commands;
using Inventory_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Inventory_Management_System.ViewModels
{
    class ItemsViewModel :BaseViewModel {

        public string _name;
        public string Name
        {
            get { return _name; }
            set{
                _name = value;
                OnpropertyChanged(nameof(Name));
            }
        }

        public string _details;
        public string Details
        { get { return _details; }
            set
            {
                _details = value;
                OnpropertyChanged(nameof(Details));
            }
        }

        public double _price;
        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnpropertyChanged(nameof(Price));
            }
        }
        public string _measuringUnit;
        public string MeasuringUnit
        {
            get { return _measuringUnit; }
            set
            {
                _measuringUnit = value;
                OnpropertyChanged(nameof(MeasuringUnit));
            }
        }
        public double _reorderLevel;
        public double ReOrderLevel
        {
            get { return _reorderLevel; }
            set
            {
                _reorderLevel = value;
                OnpropertyChanged(nameof(ReOrderLevel));
            }
        }
        public ObservableCollection<item> _items;
        public ObservableCollection<item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnpropertyChanged(nameof(Items));
            }
        }
        public item _selectedItem;
        public item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if(_selectedItem!=null)
                {
                    Name = _selectedItem.Name;
                    Details = _selectedItem.Details;
                    Price = _selectedItem.Price;
                    MeasuringUnit = _selectedItem.MeasuringUnit;
                    ReOrderLevel = _selectedItem.ReOrderLevel;
                }
                OnpropertyChanged(nameof(SelectedItem));
            }
        }
        //commands
        public ICommand SaveCommand {  get; }
        public ICommand UpdateCommand { get; }

        public ItemsViewModel()
        {
            Name = "";
            Details = "";
            Price = 0;
            MeasuringUnit = "";
            ReOrderLevel = 10;
            SaveCommand = new RelayCommand(SaveItem, CanSaveitem);
            UpdateCommand = new RelayCommand(UpdateItem, CanUpdateItem);
          
        }
        private bool CanSaveitem(object obj)
        {
            return !string.IsNullOrEmpty(Name) && Price > 0;
        }
        private void SaveItem(object obj)
        {
            item item = new item
            {
                Name = Name,
                Details = Details, 
                Price = Price,
                MeasuringUnit = MeasuringUnit,
                ReOrderLevel = ReOrderLevel
            };
            InventoryDBContext db = new InventoryDBContext();
            db.items.Add(item);
            db.SaveChanges();
            // refresh list
           
            // clear inputs
            Name = string.Empty;
            Details = string.Empty;
            Price = 0;
            MeasuringUnit = string.Empty;
            ReOrderLevel = 10;
        }
        private bool CanUpdateItem(object obj)
        {
            return SelectedItem!=null && !string.IsNullOrEmpty(Name) && Price > 0;
        }
        private void UpdateItem(object obj)
        {
            InventoryDBContext db = new InventoryDBContext();
            item item = db.items.Find(SelectedItem.itemId);
            if(item!=null)
            {
                item.Name = Name;
                item.Details = Details;
                item.Price = Price;
                item.MeasuringUnit = MeasuringUnit;
                item.ReOrderLevel = ReOrderLevel;
                db.SaveChanges();
        
            }
        }
        private void LoadItems()
        {
            InventoryDBContext db = new InventoryDBContext();
            Items = new ObservableCollection<item>(db.items);
        }
       
    }
}
