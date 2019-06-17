using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Data.EntityFramework.Migrations
{
    public partial class Enti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Region = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_SubCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    SubCategoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adverts_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(maxLength: 200, nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    AdvertId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertComments_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Base64 = table.Column<string>(nullable: false),
                    AdvertId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    AdvertId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { -1, "Транспорт", null },
                    { -2, "недвижимость", null },
                    { -3, "Работа", null },
                    { -4, "Услуги", null },
                    { -5, "Личные вещи", null },
                    { -6, "Для дома и дачи", null },
                    { -7, "Бытовая электроника", null },
                    { -8, "Хобби и отдых", null },
                    { -9, "Животные", null },
                    { -42, "Для бизнеса", null }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { -10, "Автомобили", -1 },
                    { -92, "Птицы", -9 },
                    { -91, "Кошки", -9 },
                    { -90, "Собаки", -9 },
                    { -83, "Коллекционирование", -8 },
                    { -82, "Книги и журналы", -8 },
                    { -81, "Велосипеды", -8 },
                    { -80, "Билеты и путешествия", -8 },
                    { -73, "Ноутбуки", -7 },
                    { -72, "Настольные компьютеры", -7 },
                    { -71, "Игры, пристави и программы", -7 },
                    { -70, "Аудио и видео", -7 },
                    { -63, "Продукты питания", -6 },
                    { -62, "Посуда и товары для кухни", -6 },
                    { -61, "Мебель и интерьер", -6 },
                    { -43, "Готовый бизнес", -42 },
                    { -60, "Бытовая техника", -6 },
                    { -53, "Часы и украшения", -5 },
                    { -52, "Товары для детей и игрушки", -5 },
                    { -51, "Детская одежда и обувь", -5 },
                    { -50, "Одежда, обувь, аксессуары", -5 },
                    { -40, "Предложение услуг", -4 },
                    { -31, "Резюме", -3 },
                    { -30, "Вакансии", -3 },
                    { -23, "Земельные участки", -2 },
                    { -22, "Дома, дачи, коттеджи", -2 },
                    { -21, "Комнаты", -2 },
                    { -20, "Квартиры", -2 },
                    { -13, "Водный транспорт", -1 },
                    { -12, "Грузовики и спецтехника", -1 },
                    { -11, "Мотоциклы и мото-техника", -1 },
                    { -54, "Красота и здоровье", -5 },
                    { -44, "Оборудование для бизнеса", -42 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertComments_AdvertId",
                table: "AdvertComments",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_AddressId",
                table: "Adverts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_SubCategoryId",
                table: "Adverts",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AdvertId",
                table: "Images",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_AdvertId",
                table: "Likes",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_ParentId",
                table: "SubCategories",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertComments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "SubCategories");
        }
    }
}
