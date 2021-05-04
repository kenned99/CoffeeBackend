using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess1.Migrations
{
    public partial class coffeecompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coffee_CoffeeCompany_CompanyId",
                table: "Coffee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeCompany",
                table: "CoffeeCompany");

            migrationBuilder.RenameTable(
                name: "CoffeeCompany",
                newName: "CoffeeCompanies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeCompanies",
                table: "CoffeeCompanies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coffee_CoffeeCompanies_CompanyId",
                table: "Coffee",
                column: "CompanyId",
                principalTable: "CoffeeCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coffee_CoffeeCompanies_CompanyId",
                table: "Coffee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeCompanies",
                table: "CoffeeCompanies");

            migrationBuilder.RenameTable(
                name: "CoffeeCompanies",
                newName: "CoffeeCompany");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeCompany",
                table: "CoffeeCompany",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coffee_CoffeeCompany_CompanyId",
                table: "Coffee",
                column: "CompanyId",
                principalTable: "CoffeeCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
