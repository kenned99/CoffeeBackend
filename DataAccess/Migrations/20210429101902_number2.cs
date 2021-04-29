using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess1.Migrations
{
    public partial class number2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendUser_Friend_FriendsId",
                table: "FriendUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friend",
                table: "Friend");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "UserTokens");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "Coffee");

            migrationBuilder.RenameTable(
                name: "Friend",
                newName: "Friends");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Coffee",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "Coffee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Coffee",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coffee",
                table: "Coffee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CheckIn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckIn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeCompany", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coffee_CompanyId",
                table: "Coffee",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Coffee_UserId",
                table: "Coffee",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coffee_CoffeeCompany_CompanyId",
                table: "Coffee",
                column: "CompanyId",
                principalTable: "CoffeeCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coffee_Users_UserId",
                table: "Coffee",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendUser_Friends_FriendsId",
                table: "FriendUser",
                column: "FriendsId",
                principalTable: "Friends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coffee_CoffeeCompany_CompanyId",
                table: "Coffee");

            migrationBuilder.DropForeignKey(
                name: "FK_Coffee_Users_UserId",
                table: "Coffee");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendUser_Friends_FriendsId",
                table: "FriendUser");

            migrationBuilder.DropTable(
                name: "CheckIn");

            migrationBuilder.DropTable(
                name: "CoffeeCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coffee",
                table: "Coffee");

            migrationBuilder.DropIndex(
                name: "IX_Coffee_CompanyId",
                table: "Coffee");

            migrationBuilder.DropIndex(
                name: "IX_Coffee_UserId",
                table: "Coffee");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Coffee");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Coffee");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Coffee");

            migrationBuilder.RenameTable(
                name: "Friends",
                newName: "Friend");

            migrationBuilder.RenameTable(
                name: "Coffee",
                newName: "UserTokens");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "UserTokens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friend",
                table: "Friend",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendUser_Friend_FriendsId",
                table: "FriendUser",
                column: "FriendsId",
                principalTable: "Friend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
