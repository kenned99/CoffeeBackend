using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess1.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
