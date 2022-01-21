using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        //options ile veri tabanı yolunu startup dosyasından verebilmek için oluşturdum appdbcontext 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> Productfeatures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature()
            {
                Id = 1,
                Color = "kırmızı",
                Height = 100,
                width = 200,
                ProductId = 1
            },
            new ProductFeature()

            {
                Id = 2,
                Color = "mavi",
                Height = 300,
                width = 20,
                ProductId = 2
            }
            );

            //model oluşurken çalışacak metotlar 
            base.OnModelCreating(modelBuilder);
        }


    }
}
