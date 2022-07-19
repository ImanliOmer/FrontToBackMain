using FrontToBack.Migrations;
using FrontToBack.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderContent> SliderContents { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<Experts> Experts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<CaruselBlogs> CaruselBlogs { get; set; }
        public DbSet<Instagram> Instagrams { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Slider>().HasData(
                    new Slider { Id=1,ImgUrl= "h3-slider-background.jpg" },
                    new Slider { Id = 2, ImgUrl = "h3-slider-background-2.jpg" }
                    
                                    );
                                builder.Entity<Product>().HasData(
                    new Product { Id = 1, Name="Product1",Price=60,ImageUrl= "shop-13-img.jpg" ,CategoryId=1},
                    new Product { Id = 2, Name = "Product2", Price = 65, ImageUrl = "shop-12-img.jpg", CategoryId = 2 },
                    new Product { Id = 3, Name = "Product3", Price = 70, ImageUrl = "shop-11-img.jpg", CategoryId = 3 },
                    new Product { Id = 4, Name = "Product4", Price = 80, ImageUrl = "shop-13-img.jpg", CategoryId = 4 },
                    new Product { Id = 5, Name = "Product5", Price = 90, ImageUrl = "shop-8-img.jpg", CategoryId = 5 },
                    new Product { Id = 6, Name = "Product6", Price = 90, ImageUrl = "shop-11-img.jpg", CategoryId = 3 }
                    
                    
                                   );
            //                    builder.Entity<Category>().HasData(
            //        new Category { Id = 7, Name="Popular",Desc="Lorem ipsum" },
            //        new Category { Id = 8, Name = "Winter", Desc = "Lorem ipsum" },
            //        new Category { Id = 9, Name = "Exotic", Desc = "Lorem ipsum" },
            //        new Category { Id = 10, Name = "Varius", Desc = "Lorem ipsum" },
            //        new Category { Id = 5, Name = "Venor", Desc = "Lorem ipsum" }
            //        );
            //                    builder.Entity<Bio>().HasData(
            //        new Bio { Id = 5, ImageUrl= "logo.png",
            //            Linkedn= "https://www.linkexdin.com/" ,Facebook= "Cj0KCQjwtvqVBhCVARIsAFUxcRv7PtwND0mb_zQZOHEyCwzR8nce3lB8LQyvcAf8uu_Cb6agQSJCTJgaAkJZEALw_wcB",AuthorName="Aqil" }
                    
                    
            //                     );
            //base.OnModelCreating(builder);
            //builder.Entity<SliderContent>().HasData(
            //        new SliderContent { Id=1,Title= "<h1>Send <span>flowers</span> lorem like</h1>",Desc= "Where flowers are our inspiration to create lasting memories. Whatever the occasion, our flowers will   make it special cursus a sit amet mauris.",ImgUrl= "h2-sign-img.png" }
                  

            //                        );
            //base.OnModelCreating(builder);
            //builder.Entity<Experts>().HasData(
            //       new Experts { Id = 1, Name = "Crystal Brooks", Positation = "Florist", ImageUrl = "h3-team-img-1.png" } ,
            //new Experts { Id = 1, Name = "Shirley Hirres", Positation = "Manager", ImageUrl = "h3-team-img-2.png" },


            //   new Experts { Id = 1, Name = "Beverly", Positation = "Florist", ImageUrl = "h3-team-img-3.png" },
            //         new Experts { Id = 1, Name = "Lorem", Positation = "Manager", ImageUrl = "h3-team-img-3.png" }

            //);
            //base.OnModelCreating(builder);
        


        }

    }
}
