using ProductSystem.Model;
using ProductSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net.Http;

namespace ProductSystem.Web.Controllers
{
    public class ProductController : BaseController
    {
        [Authorize]
        public ActionResult PostComment(SubmitCommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
               var username =  this.User.Identity.GetUserName();
               var userId = this.User.Identity.GetUserId();

                this.Data.Comments.Add(new Comment() 
                { 
                    AuthorId = userId,
                    Content = commentModel.Comment,
                    ProductId = commentModel.ProductId,
                });
                try
                {
                    this.Data.SaveChanges();
                }
                catch (Exception ex)
                {

                }
                

                var viewModel = new CommentViewModel { AuthorUsername = username, Content = commentModel.Comment };
                return PartialView("_CommentPartial", viewModel);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }
        const int pageSize = 5;
        private IQueryable<ProductViewModel> GetAllProducts()
        {
            var data = this.Data.Products.All().Select(x => new ProductViewModel 
            { 
                Id = x.Id,
                ImgURL = x.ImgURL,
                Manufacturer = x.Manufacture.ManufactureName,
                Price = x.Price,
                Model = x.Model,    
            }).OrderBy(x => x.Id);
            return data;
        }
        public ActionResult List(int? id)
        {
            int pageNumber = id.GetValueOrDefault(1);

            var viewModel = GetAllProducts().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            ViewBag.Pages = Math.Ceiling((double)GetAllProducts().Count() / pageSize);

            return View(viewModel);
        }
        public ActionResult Details(int id)
        {
            var viewModel = this.Data.Products.All().Where(x => x.Id == id)
                .Select(x => new ProductDetailsViewModel
                {
                    Id = x.Id,
                    Comments = x.Comments.Select(y => new CommentViewModel { AuthorUsername = y.Author.UserName, Content = y.Content }),
                    AdditionalInfo = x.AdditionalInfo,
                    Description = x.Description,
                    ImgURL = x.ImgURL,
                    ManufacturerName = x.Manufacture.ManufactureName,
                    Price = x.Price,
                    Model = x.Model,
                }).FirstOrDefault();

            return View(viewModel);
        }
    }
}