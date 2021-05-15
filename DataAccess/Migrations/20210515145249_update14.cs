using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess1.Migrations
{
    public partial class update14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoffeeCompanyName",
                table: "Coffee",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoffeeCompanyName",
                table: "Coffee");
        }
    }
}
