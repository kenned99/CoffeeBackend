using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess1.Migrations
{
    public partial class update10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coffee_CoffeeCompanies_CompanyId",
                table: "Coffee");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Coffee",
                newName: "CoffeeCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Coffee_CompanyId",
                table: "Coffee",
                newName: "IX_Coffee_CoffeeCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coffee_CoffeeCompanies_CoffeeCompanyId",
                table: "Coffee",
                column: "CoffeeCompanyId",
                principalTable: "CoffeeCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coffee_CoffeeCompanies_CoffeeCompanyId",
                table: "Coffee");

            migrationBuilder.RenameColumn(
                name: "CoffeeCompanyId",
                table: "Coffee",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Coffee_CoffeeCompanyId",
                table: "Coffee",
                newName: "IX_Coffee_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coffee_CoffeeCompanies_CompanyId",
                table: "Coffee",
                column: "CompanyId",
                principalTable: "CoffeeCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
