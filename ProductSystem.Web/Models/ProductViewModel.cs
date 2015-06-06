using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSystem.Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }

        public string ImgURL { get; set; }

        public double Price { get; set; }
    }
}