using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess1.Migrations
{
    public partial class update15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoffeeCompanyName",
                table: "Coffee");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CoffeeRating",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeRating_UserId",
                table: "CoffeeRating",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeRating_Users_UserId",
                table: "CoffeeRating",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeRating_Users_UserId",
                table: "CoffeeRating");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeRating_UserId",
                table: "CoffeeRating");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CoffeeRating");

            migrationBuilder.AddColumn<string>(
                name: "CoffeeCompanyName",
                table: "Coffee",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
