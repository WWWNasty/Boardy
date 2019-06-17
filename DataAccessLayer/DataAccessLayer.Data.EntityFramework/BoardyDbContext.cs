using DataAccessLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data.EntityFramework
{
    public class BoardyDbContext : DbContext
    {
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdvertComment> AdvertComments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AdvertComment>()
            //    .HasOne(p => p.Advert)
            //    .WithMany(t => t.AdvertComments)
            //    .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory
                {
                    Id = -1,
                    Name = "Transport"
                },
                new SubCategory
                {
                    Id = -10,
                    Name = "Cars",
                    ParentId = -1
                },
                new SubCategory
                {
                    Id = -11,
                    Name = "Motorcycles",
                    ParentId = -1
                },
                new SubCategory
                {
                    Id = -12,
                    Name = "Trucks and special equipment",
                    ParentId = -1
                },
                new SubCategory
                {
                    Id = -13,
                    Name = "Water transport",
                    ParentId = -1
                },
                new SubCategory
                {
                    Id = -2,
                    Name = "Realty"
                },
                new SubCategory
                {
                    Id = -20,
                    Name = "Apartment",
                    ParentId = -2
                },
                new SubCategory
                {
                    Id = -21,
                    Name = "Rooms",
                    ParentId = -2
                },
                new SubCategory
                {
                    Id = -22,
                    Name = "Houses and cottages",
                    ParentId = -2
                },
                new SubCategory
                {
                    Id = -23,
                    Name = "Ground area",
                    ParentId = -2
                },
                new SubCategory
                {
                    Id = -3,
                    Name = "Work"
                },
                new SubCategory
                {
                    Id = -30,
                    Name = "Vacancy",
                    ParentId = -3
                },
                new SubCategory
                {
                    Id = -31,
                    Name = "Resume",
                    ParentId = -3
                },
                new SubCategory
                {
                    Id = -4,
                    Name = "Service"
                },
                new SubCategory
                {
                    Id = -40,
                    Name = "Service offering",
                    ParentId = -4
                },
                new SubCategory
                {
                    Id = -5,
                    Name = "Personal thing"
                },
                new SubCategory
                {
                    Id = -50,
                    Name = "Clothes, shoes, accessories",
                    ParentId = -5
                },
                new SubCategory
                {
                    Id = -51,
                    Name = "Children's clothing and shoes",
                    ParentId = -5
                },
                new SubCategory
                {
                    Id = -52,
                    Name = "Goods for children and toys",
                    ParentId = -5
                },
                new SubCategory
                {
                    Id = -53,
                    Name = "Watches and jewellery",
                    ParentId = -5
                },
                new SubCategory
                {
                    Id = -54,
                    Name = "Health and beauty",
                    ParentId = -5
                },
                new SubCategory
                {
                    Id = -6,
                    Name = "For home and garden"
                },
                new SubCategory
                {
                    Id = -60,
                    Name = "home appliances",
                    ParentId = -6
                },
                new SubCategory
                {
                    Id = -61,
                    Name = "Furniture and interior",
                    ParentId = -6
                },
                new SubCategory
                {
                    Id = -62,
                    Name = "Kitchen utensils and goods",
                    ParentId = -6
                },
                new SubCategory
                {
                    Id = -63,
                    Name = "food supply",
                    ParentId = -6
                },
            new SubCategory
                {
                    Id = -7,
                    Name = "consumer electronics"
            },
                new SubCategory
                {
                    Id = -70,
                    Name = "Audio and video",
                    ParentId = -7
                },
                new SubCategory
                {
                    Id = -71,
                    Name = "Games, consoles and programs",
                    ParentId = -7
                },
                new SubCategory
                {
                    Id = -72,
                    Name = "desktop computer",
                    ParentId = -7
                },
                new SubCategory
                {
                    Id = -73,
                    Name = "laptop",
                    ParentId = -7
                },
            new SubCategory
                {
                    Id = -8,
                    Name = "Hobbies and recreation"
            },
                new SubCategory
                {
                    Id = -80,
                    Name = "Tickets and travel",
                    ParentId = -8
                },
                new SubCategory
                {
                    Id = -81,
                    Name = "bicycle",
                    ParentId = -8
                },
                new SubCategory
                {
                    Id = -82,
                    Name = "Books and magazines",
                    ParentId = -8
                },
                new SubCategory
                {
                    Id = -83,
                    Name = "collecting",
                    ParentId = -8
                },
            new SubCategory
                {
                    Id = -9,
                    Name = "animal"
            },
                new SubCategory
                {
                    Id = -90,
                    Name = "dog",
                    ParentId = -9
                },
                new SubCategory
                {
                    Id = -91,
                    Name = "сat",
                    ParentId = -9
                },
                new SubCategory
                {
                    Id = -92,
                    Name = "bird",
                    ParentId = -9
                },
            new SubCategory
                {
                    Id = -42,
                    Name = "for business"
            },
                new SubCategory
                {
                    Id = -43,
                    Name = "ready business",
                    ParentId = -42
                },
                new SubCategory
                {
                    Id = -44,
                    Name = "Business equipment",
                    ParentId = -42
                }
             
                );
        }

        public BoardyDbContext(DbContextOptions<BoardyDbContext> options) : base(options)
        {
        }
    }
}