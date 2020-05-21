using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class UserRoleInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_UserRole_Edu_User_UserId",
                table: "Edu_UserRole");

            migrationBuilder.DropIndex(
                name: "IX_Edu_UserRole_UserId",
                table: "Edu_UserRole");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Edu_UserRole");

            migrationBuilder.AddColumn<Guid>(
                name: "UserRoleId",
                table: "Edu_User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_User_UserRoleId",
                table: "Edu_User",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_User_Edu_UserRole_UserRoleId",
                table: "Edu_User",
                column: "UserRoleId",
                principalTable: "Edu_UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_User_Edu_UserRole_UserRoleId",
                table: "Edu_User");

            migrationBuilder.DropIndex(
                name: "IX_Edu_User_UserRoleId",
                table: "Edu_User");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Edu_User");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Edu_UserRole",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_UserRole_UserId",
                table: "Edu_UserRole",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_UserRole_Edu_User_UserId",
                table: "Edu_UserRole",
                column: "UserId",
                principalTable: "Edu_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
