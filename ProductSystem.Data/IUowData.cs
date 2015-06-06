using ProductSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Data
{
    public interface IUowData
    {
        IRepository<Products> Products { get; }

        IRepository<Manufacturer> Manufacturers { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Vote> Votes { get; }

        // IRepository<Appli> Votes { get; }

        int SaveChanges();
    }
}
