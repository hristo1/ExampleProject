using Microsoft.AspNet.Identity.EntityFramework;
using ProductSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<Products> Products { get; set; }
        public IDbSet<Manufacturer> Manufacturers { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Vote> Votes { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
