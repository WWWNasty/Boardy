using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Data.EntityFramework.Migrations
{
    public partial class Priseint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Adverts",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Adverts",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
