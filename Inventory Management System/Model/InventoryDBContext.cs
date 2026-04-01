using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Inventory_Management_System.Model
{
    class InventoryDBContext:DbContext
    {
        public InventoryDBContext() : base("ConStr") { }
        public DbSet<item> items { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<SupplyDetail> SupplyDetails { get; set; }
        public DbSet<Stock> Stocks { get; set; }

       pr
    }
}
