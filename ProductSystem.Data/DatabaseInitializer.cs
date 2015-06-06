using ProductSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Data
{
    public class DatabaseInitializer : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DatabaseInitializer()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
        
        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Products.Count() > 0)
            {
                return;
            }
            Random rand = new Random();
            Manufacturer sampleManufacurer = new Manufacturer { ManufactureName = "Tesla" };
            ApplicationUser user = new ApplicationUser() { UserName = "TestUser", Email = "tesla@mail.com" };

            for (int i = 0; i < 10; i++)
            {
                Products product = new Products();
                product.ImgURL = "http://image.motortrend.com/f/oftheyear/car/1301_2013_motor_trend_car_of_the_year_tesla_model_s/41007734+w644/2013-tesla-model-s-front-1.jpg";
                product.Model = "Model";
                product.Price = rand.Next(50000, 100000);
                product.Description = "SomeText";
                product.Manufacture = sampleManufacurer;
                var voteC  = rand.Next(0,10);
                for (int j = 0; j < voteC ; j++)
                {
                    product.Votes.Add(new Vote { Product = product, VotedBy = user });
                }
                
                var commentC = rand.Next(0, 10);
                for (int j = 0; j < commentC; j++)
                {
                    product.Comments.Add(new Comment { Content = "Test comments", Author = user});
                }
                context.Products.Add(product); 
            }
            context.SaveChanges();
            base.Seed(context);
        }
       
    }
}
