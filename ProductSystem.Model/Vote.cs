using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Model
{
    public class Vote
    {
        [Key]
        public int ID { get; set; }

        [Requered]
        public string VotedById { get; set; }

        public virtual ApplicationUser VotedBy { get; set; }
        
        public int ProductID { get; set; }
        
        [Required]
        public virtual Products Product{ get; set; }
    }
}
