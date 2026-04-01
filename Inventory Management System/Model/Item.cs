using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Model
{
    public class item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Details { get; set; }
        public double Price { get; set; }
        public string MeasuringUnit { get; set; }
        public double ReOrderLevel { get; set; } = 10;

    }
}
