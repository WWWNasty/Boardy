﻿// <auto-generated />
using System;
using DataAccessLayer.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Data.EntityFramework.Migrations
{
    [DbContext(typeof(BoardyDbContext))]
    [Migration("20190430155243_Enti")]
    partial class Enti
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<decimal>("Price");

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
                            Name = "Транспорт"
                        },
                        new
                        {
                            Id = -10,
                            Name = "Автомобили",
                            ParentId = -1
                        },
                        new
                        {
                            Id = -11,
                            Name = "Мотоциклы и мото-техника",
                            ParentId = -1
                        },
                        new
                        {
                            Id = -12,
                            Name = "Грузовики и спецтехника",
                            ParentId = -1
                        },
                        new
                        {
                            Id = -13,
                            Name = "Водный транспорт",
                            ParentId = -1
                        },
                        new
                        {
                            Id = -2,
                            Name = "недвижимость"
                        },
                        new
                        {
                            Id = -20,
                            Name = "Квартиры",
                            ParentId = -2
                        },
                        new
                        {
                            Id = -21,
                            Name = "Комнаты",
                            ParentId = -2
                        },
                        new
                        {
                            Id = -22,
                            Name = "Дома, дачи, коттеджи",
                            ParentId = -2
                        },
                        new
                        {
                            Id = -23,
                            Name = "Земельные участки",
                            ParentId = -2
                        },
                        new
                        {
                            Id = -3,
                            Name = "Работа"
                        },
                        new
                        {
                            Id = -30,
                            Name = "Вакансии",
                            ParentId = -3
                        },
                        new
                        {
                            Id = -31,
                            Name = "Резюме",
                            ParentId = -3
                        },
                        new
                        {
                            Id = -4,
                            Name = "Услуги"
                        },
                        new
                        {
                            Id = -40,
                            Name = "Предложение услуг",
                            ParentId = -4
                        },
                        new
                        {
                            Id = -5,
                            Name = "Личные вещи"
                        },
                        new
                        {
                            Id = -50,
                            Name = "Одежда, обувь, аксессуары",
                            ParentId = -5
                        },
                        new
                        {
                            Id = -51,
                            Name = "Детская одежда и обувь",
                            ParentId = -5
                        },
                        new
                        {
                            Id = -52,
                            Name = "Товары для детей и игрушки",
                            ParentId = -5
                        },
                        new
                        {
                            Id = -53,
                            Name = "Часы и украшения",
                            ParentId = -5
                        },
                        new
                        {
                            Id = -54,
                            Name = "Красота и здоровье",
                            ParentId = -5
                        },
                        new
                        {
                            Id = -6,
                            Name = "Для дома и дачи"
                        },
                        new
                        {
                            Id = -60,
                            Name = "Бытовая техника",
                            ParentId = -6
                        },
                        new
                        {
                            Id = -61,
                            Name = "Мебель и интерьер",
                            ParentId = -6
                        },
                        new
                        {
                            Id = -62,
                            Name = "Посуда и товары для кухни",
                            ParentId = -6
                        },
                        new
                        {
                            Id = -63,
                            Name = "Продукты питания",
                            ParentId = -6
                        },
                        new
                        {
                            Id = -7,
                            Name = "Бытовая электроника"
                        },
                        new
                        {
                            Id = -70,
                            Name = "Аудио и видео",
                            ParentId = -7
                        },
                        new
                        {
                            Id = -71,
                            Name = "Игры, пристави и программы",
                            ParentId = -7
                        },
                        new
                        {
                            Id = -72,
                            Name = "Настольные компьютеры",
                            ParentId = -7
                        },
                        new
                        {
                            Id = -73,
                            Name = "Ноутбуки",
                            ParentId = -7
                        },
                        new
                        {
                            Id = -8,
                            Name = "Хобби и отдых"
                        },
                        new
                        {
                            Id = -80,
                            Name = "Билеты и путешествия",
                            ParentId = -8
                        },
                        new
                        {
                            Id = -81,
                            Name = "Велосипеды",
                            ParentId = -8
                        },
                        new
                        {
                            Id = -82,
                            Name = "Книги и журналы",
                            ParentId = -8
                        },
                        new
                        {
                            Id = -83,
                            Name = "Коллекционирование",
                            ParentId = -8
                        },
                        new
                        {
                            Id = -9,
                            Name = "Животные"
                        },
                        new
                        {
                            Id = -90,
                            Name = "Собаки",
                            ParentId = -9
                        },
                        new
                        {
                            Id = -91,
                            Name = "Кошки",
                            ParentId = -9
                        },
                        new
                        {
                            Id = -92,
                            Name = "Птицы",
                            ParentId = -9
                        },
                        new
                        {
                            Id = -42,
                            Name = "Для бизнеса"
                        },
                        new
                        {
                            Id = -43,
                            Name = "Готовый бизнес",
                            ParentId = -42
                        },
                        new
                        {
                            Id = -44,
                            Name = "Оборудование для бизнеса",
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
