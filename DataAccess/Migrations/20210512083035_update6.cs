using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess1.Migrations
{
    public partial class update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeCoffeeCompany");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Coffee",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coffee_CompanyId",
                table: "Coffee",
                column: "CompanyId");

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

            migrationBuilder.DropIndex(
                name: "IX_Coffee_CompanyId",
                table: "Coffee");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Coffee");

            migrationBuilder.CreateTable(
                name: "CoffeeCoffeeCompany",
                columns: table => new
                {
                    CoffeeCompaniesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoffeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeCoffeeCompany", x => new { x.CoffeeCompaniesId, x.CoffeeId });
                    table.ForeignKey(
                        name: "FK_CoffeeCoffeeCompany_Coffee_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeCoffeeCompany_CoffeeCompanies_CoffeeCompaniesId",
                        column: x => x.CoffeeCompaniesId,
                        principalTable: "CoffeeCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeCoffeeCompany_CoffeeId",
                table: "CoffeeCoffeeCompany",
                column: "CoffeeId");
        }
    }
}
