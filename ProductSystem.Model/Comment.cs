using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        [Requered]
        public string AuthorId { get; set; }
   
        public virtual ApplicationUser Author { get; set; }
       
        [Requered]
        public int ProductId { get; set; }
       
        public virtual Products Product { get; set; }
        
        [Requered]
        public string Content { get; set; }
    }
}
