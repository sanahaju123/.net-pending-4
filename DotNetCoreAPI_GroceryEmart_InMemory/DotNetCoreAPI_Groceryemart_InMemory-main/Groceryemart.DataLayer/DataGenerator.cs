using GroceryEmart.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GroceryEmart.DataLayer
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GroceryemartDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<GroceryemartDbContext>>()))
            {
                if (context.categories.Any())
                {
                    return;   // Data was already seeded
                }
                context.categories.AddRange(
                    new Category
                    {
                        Id = 1,
                        CatId = 0,
                        Title = "Home",
                        Url = "~/",
                        OpenInNewWindow = false
                    },
                new Category
                {
                    Id = 2,
                    CatId = 1,
                    Title = "Electronics",
                    Url = "~/Home/Index/1",
                    OpenInNewWindow = false
                },
                new Category
                {
                    Id = 3,
                    CatId = 2,
                    Title = "TVs Appliance",
                    Url = "~/Home/Index/2",
                    OpenInNewWindow = false
                },
                new Category
                {
                    Id = 4,
                    CatId = 3,
                    Title = "Mean",
                    Url = "~/Home/Index/3",
                    OpenInNewWindow = false
                },
                new Category
                {
                    Id = 5,
                    CatId = 4,
                    Title = "Woman",
                    Url = "~/Home/Index/4",
                    OpenInNewWindow = false
                },
                new Category
                {
                    Id = 6,
                    CatId = 5,
                    Title = "Bady Kids",
                    Url = "~/Home/Index/5",
                    OpenInNewWindow = false
                },
                new Category
                {
                    Id = 7,
                    CatId = 6,
                    Title = "Home Furniture",
                    Url = "~/Home/Index/6",
                    OpenInNewWindow = false
                },
                new Category
                {
                    Id = 8,
                    CatId = 7,
                    Title = "Sports Book More",
                    Url = "~/Home/Index/7",
                    OpenInNewWindow = false
                });
                context.SaveChanges();
                if (context.products.Any())
                {
                    return;   // Data was already seeded
                }
                context.products.AddRange(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Samsung",
                    Description = "RAM-3 GB, SSD-128 GB,Processor-Snap Dragon 805, Retina Display-3",
                    Amount = 12900,
                    stock = 10,
                    CatId = 1
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Samsung - TV",
                    Description = "Size - 72, SSD-128 GB, Processor-Snap Dragon 805, Screen - 4500X3000PX",
                    Amount = 12990,
                    stock = 13,
                    CatId = 2
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Sports Runnig Shoes - Reebok",
                    Description = "Size - 8, Color - Brown White",
                    Amount = 1900,
                    stock = 101,
                    CatId = 3
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "One Pic - Kurti",
                    Description = "Size - 40, Height - 5Ft, Color - Pink",
                    Amount = 990,
                    stock = 183,
                    CatId = 4
                });
                context.SaveChanges();
            }
        }
    }
}
