using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Data.EntityFramework.Migrations
{
    public partial class _123456 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Price",
                table: "Adverts",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Adverts",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
