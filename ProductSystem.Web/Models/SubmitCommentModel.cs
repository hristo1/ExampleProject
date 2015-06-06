using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductSystem.Model;
using System.ComponentModel.DataAnnotations;

namespace ProductSystem.Web.Models
{
    public class SubmitCommentModel
    {
        [Required]
        [EmailValidation]
        public string Comment { get; set; }

        [Required]
        public int ProductId { get; set;  }
    }
}