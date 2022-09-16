using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWPF.Models
{
    internal class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Jihoz Madelni Kirting")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Xona Raqamni Kirting")]
        public string Room { get; set; }
        [Required(ErrorMessage = "Javobgar shaxs ismini Kirting")]
        public string Responsible { get; set; }
        public string MoreInformation { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
