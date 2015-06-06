using ProductSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (this.HttpContext.Cache["HomePageProducts"] == null)
            {


                // return Content(this.Data.Manufacturers.All().Count().ToString());
                var listOfProducts = this.Data.Products.All()
                    .OrderByDescending(x => x.Votes.Count())
                    .Take(9)
                    .Select(x => new ProductViewModel
                    {
                        Id = x.Id,
                        Manufacturer = x.Manufacture.ManufactureName,
                        ImgURL = x.ImgURL,
                        Model = x.Model,
                        Price = x.Price
                    });
                this.HttpContext.Cache.Add("HomePageProducts", listOfProducts.ToList(), null, DateTime.Now.AddHours(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }
            return View(this.HttpContext.Cache["HomePageProducts"]);
        }

    }
}