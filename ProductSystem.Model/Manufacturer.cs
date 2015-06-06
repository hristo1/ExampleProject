using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Model
{
    public class Manufacturer
    {
        private ICollection<Products> products;
        public Manufacturer()
        {
            this.products = new  HashSet<Products>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string ManufactureName { get; set; }

        public ICollection<Products> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
