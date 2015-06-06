using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSystem.Web.Models
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }
        public string AdditionalInfo { get; set; }

        public double Price { get; set; }

        public string ImgURL { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}