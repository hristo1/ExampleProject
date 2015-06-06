using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Model
{
    public class Products
    {
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;    
        public  Products(){
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
        }

        [Key]
        public int Id { get; set; }

        [Requered]
        public int ManufacturerId { get; set; }
        /// <summary>
        /// Name of the manufacturer
        /// </summary>
     
        public virtual Manufacturer Manufacture { get; set; }
        /// <summary>
        /// Model of the product
        /// </summary>
        [Required]
        public string Model { get; set; }
        /// <summary>
        /// Information about the product
        /// </summary>
        [Required]
        public string Description { get; set; }
        
        /// <summary>
        /// If needed 
        /// </summary>
        public string AdditionalInfo { get; set; }
       
        /// <summary>  
        /// In EUR
        /// </summary>
        [Required]
        public double Price { get; set; }
        /// <summary>
        /// Add img
        /// </summary>
        public string ImgURL { get; set ; }
        public ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
        public ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

    }
}
