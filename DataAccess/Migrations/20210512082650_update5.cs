using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess1.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeCompanies_Coffee_CoffeeId",
                table: "CoffeeCompanies");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeCompanies_CoffeeId",
                table: "CoffeeCompanies");

            migrationBuilder.DropColumn(
                name: "CoffeeId",
                table: "CoffeeCompanies");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeCoffeeCompany");

            migrationBuilder.AddColumn<Guid>(
                name: "CoffeeId",
                table: "CoffeeCompanies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeCompanies_CoffeeId",
                table: "CoffeeCompanies",
                column: "CoffeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeCompanies_Coffee_CoffeeId",
                table: "CoffeeCompanies",
                column: "CoffeeId",
                principalTable: "Coffee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
