using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System.Model
{
    internal class Supply
    {
        [Key]
        public int SupplyId { get; set; }
        [Required]
        public int SupplierId { get; set; }
        public DateTime date { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

    }
}
