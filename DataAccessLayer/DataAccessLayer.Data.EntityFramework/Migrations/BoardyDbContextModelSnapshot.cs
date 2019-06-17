﻿// <auto-generated />
using System;
using DataAccessLayer.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Data.EntityFramework.Migrations
{
    [DbContext(typeof(BoardyDbContext))]
    partial class BoardyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Models.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("HouseNumber");

                    b.Property<string>("Region")
                        .IsRequired();

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Entities.Advert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<long>("Price");

                    b.Property<int?>("SubCategoryId")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Adverts");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Entities.AdvertComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdvertId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("AdvertId");

                    b.ToTable("AdvertComments");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdvertId");

                    b.Property<string>("Base64")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AdvertId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Entities.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdvertId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AdvertId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Entities.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("SubCategories");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "Transport"
                        },
                        new
                        {
                            Id = -10,
                            Name = "Cars",
                            ParentId = -1
                        },
                        new
                        {
                            Id = -11,
                            Name = "Motorcycles",
                            ParentId = -1
                        },
                        new
                        {
                            Id = -12,
                            Name = "Trucks and special equipment",
                            ParentId = -1
                        },
                        new
                        {
                            Id = -13,
                            Name = "Water transport",
                            ParentId = -1
                        },
                        new
                        {
                            Id = -2,
                            Name = "Realty"
                        },
                        new
                        {
                            Id = -20,
                            Name = "Apartment",
                            ParentId = -2
                        },
                        new
                        {
                            Id = -21,
                            Name = "Rooms",
                            ParentId = -2
                        },
                        new
                        {
                            Id = -22,
                            Name = "Houses and cottages",
                            ParentId = -2
                        },
                        new
                        {
                            Id = -23,
                            Name = "Ground area",
                            ParentId = -2
                        },
                        new
                        {
                            Id = -3,
                            Name = "Work"
                        },
                        new
                        {
                            Id = -30,
                            Name = "Vacancy",
                            ParentId = -3
                        },
                        new
                        {
                            Id = -31,
                            Name = "Resume",
                            ParentId = -3
                        },
                        new
                        {
                            Id = -4,
                            Name = "Service"
                        },
                        new
                        {
                            Id = -40,
                            Name = "Service offering",
                            ParentId = -4
                        },
                        new
                        {
                            Id = -5,
                            Name = "Personal thing"
                        },
                        new
                        {
                            Id = -50,
                            Name = "Clothes, shoes, accessories",
                            ParentId = -5
                        },
                        new
                        {
                            Id = -51,
                            Name = "Children's clothing and shoes",
                            ParentId = -5
                        },
                        new
                        {
                            Id = -52,
                            Name = "Goods for children and toys",
                            ParentId = -5
                        },
                        new
                        {
                            Id = -53,
                            Name = "Watches and jewellery",
                            ParentId = -5
                        },
                        new
                        {
                            Id = -54,
                            Name = "Health and beauty",
                            ParentId = -5
                        },
                        new
                        {
                            Id = -6,
                            Name = "For home and garden"
                        },
                        new
                        {
                            Id = -60,
                            Name = "home appliances",
                            ParentId = -6
                        },
                        new
                        {
                            Id = -61,
                            Name = "Furniture and interior",
                            ParentId = -6
                        },
                        new
                        {
                            Id = -62,
                            Name = "Kitchen utensils and goods",
                            ParentId = -6
                        },
                        new
                        {
                            Id = -63,
                            Name = "food supply",
                            ParentId = -6
                        },
                        new
                        {
                            Id = -7,
                            Name = "consumer electronics"
                        },
                        new
                        {
                            Id = -70,
                            Name = "Audio and video",
                            ParentId = -7
                        },
                        new
                        {
                            Id = -71,
                            Name = "Games, consoles and programs",
                            ParentId = -7
                        },
                        new
                        {
                            Id = -72,
                            Name = "desktop computer",
                            ParentId = -7
                        },
                        new
                        {
                            Id = -73,
                            Name = "laptop",
                            ParentId = -7
                        },
                        new
                        {
                            Id = -8,
                            Name = "Hobbies and recreation"
                        },
                        new
                        {
                            Id = -80,
                            Name = "Tickets and travel",
                            ParentId = -8
                        },
                        new
                        {
                            Id = -81,
                            Name = "bicycle",
                            ParentId = -8
                        },
                        new
                        {
                            Id = -82,
                            Name = "Books and magazines",
                            ParentId = -8
                        },
                        new
                        {
                            Id = -83,
                            Name = "collecting",
                            ParentId = -8
                        },
                        new
                        {
                            Id = -9,
                            Name = "animal"
                        },
                        new
                        {
                            Id = -90,
                            Name = "dog",
                            ParentId = -9
                        },
                        new
                        {
                            Id = -91,
                            Name = "сat",
                            ParentId = -9
                        },
                        new
                        {
                            Id = -92,
                            Name = "bird",
                            ParentId = -9
                        },
                        new
                        {
                            Id = -42,
                            Name = "for business"
                        },
                        new
                        {
                            Id = -43,
                            Name = "ready business",
                            ParentId = -42
                        },
                        new
                        {
                            Id = -44,
                            Name = "Business equipment",
                            ParentId = -42
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Models.Entities.Advert", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Entities.Address", "Address")
                        .WithMany("Advert")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccessLayer.Models.Entities.SubCategory", "SubCategory")
                        .WithMany("Adverts")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccessLayer.Models.Entities.AdvertComment", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Entities.Advert", "Advert")
                        .WithMany("AdvertComments")
                        .HasForeignKey("AdvertId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccessLayer.Models.Entities.Image", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Entities.Advert", "Advert")
                        .WithMany("AdvertImages")
                        .HasForeignKey("AdvertId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccessLayer.Models.Entities.Like", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Entities.Advert", "Advert")
                        .WithMany("Likes")
                        .HasForeignKey("AdvertId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccessLayer.Models.Entities.SubCategory", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Entities.SubCategory", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}