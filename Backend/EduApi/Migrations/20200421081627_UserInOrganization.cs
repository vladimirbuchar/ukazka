using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class UserInOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Organization_Link_UserInOrganization_UserInOrganizationId",
                table: "Edu_Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Edu_OrganizationRole_Link_UserInOrganization_UserInOrganizationId",
                table: "Edu_OrganizationRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Edu_User_Link_UserInOrganization_UserInOrganizationId",
                table: "Edu_User");

            migrationBuilder.DropIndex(
                name: "IX_Edu_User_UserInOrganizationId",
                table: "Edu_User");

            migrationBuilder.DropIndex(
                name: "IX_Edu_OrganizationRole_UserInOrganizationId",
                table: "Edu_OrganizationRole");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Organization_UserInOrganizationId",
                table: "Edu_Organization");

            migrationBuilder.DropColumn(
                name: "UserInOrganizationId",
                table: "Edu_User");

            migrationBuilder.DropColumn(
                name: "UserInOrganizationId",
                table: "Edu_OrganizationRole");

            migrationBuilder.DropColumn(
                name: "UserInOrganizationId",
                table: "Edu_Organization");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Link_UserInOrganization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationRoleId",
                table: "Link_UserInOrganization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Link_UserInOrganization",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Link_UserInOrganization_OrganizationId",
                table: "Link_UserInOrganization",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_UserInOrganization_OrganizationRoleId",
                table: "Link_UserInOrganization",
                column: "OrganizationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_UserInOrganization_UserId",
                table: "Link_UserInOrganization",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_UserInOrganization_Edu_Organization_OrganizationId",
                table: "Link_UserInOrganization",
                column: "OrganizationId",
                principalTable: "Edu_Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_UserInOrganization_Edu_OrganizationRole_OrganizationRoleId",
                table: "Link_UserInOrganization",
                column: "OrganizationRoleId",
                principalTable: "Edu_OrganizationRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_UserInOrganization_Edu_User_UserId",
                table: "Link_UserInOrganization",
                column: "UserId",
                principalTable: "Edu_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_UserInOrganization_Edu_Organization_OrganizationId",
                table: "Link_UserInOrganization");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_UserInOrganization_Edu_OrganizationRole_OrganizationRoleId",
                table: "Link_UserInOrganization");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_UserInOrganization_Edu_User_UserId",
                table: "Link_UserInOrganization");

            migrationBuilder.DropIndex(
                name: "IX_Link_UserInOrganization_OrganizationId",
                table: "Link_UserInOrganization");

            migrationBuilder.DropIndex(
                name: "IX_Link_UserInOrganization_OrganizationRoleId",
                table: "Link_UserInOrganization");

            migrationBuilder.DropIndex(
                name: "IX_Link_UserInOrganization_UserId",
                table: "Link_UserInOrganization");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Link_UserInOrganization");

            migrationBuilder.DropColumn(
                name: "OrganizationRoleId",
                table: "Link_UserInOrganization");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Link_UserInOrganization");

            migrationBuilder.AddColumn<Guid>(
                name: "UserInOrganizationId",
                table: "Edu_User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserInOrganizationId",
                table: "Edu_OrganizationRole",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserInOrganizationId",
                table: "Edu_Organization",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_User_UserInOrganizationId",
                table: "Edu_User",
                column: "UserInOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationRole_UserInOrganizationId",
                table: "Edu_OrganizationRole",
                column: "UserInOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Organization_UserInOrganizationId",
                table: "Edu_Organization",
                column: "UserInOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Organization_Link_UserInOrganization_UserInOrganizationId",
                table: "Edu_Organization",
                column: "UserInOrganizationId",
                principalTable: "Link_UserInOrganization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_OrganizationRole_Link_UserInOrganization_UserInOrganizationId",
                table: "Edu_OrganizationRole",
                column: "UserInOrganizationId",
                principalTable: "Link_UserInOrganization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_User_Link_UserInOrganization_UserInOrganizationId",
                table: "Edu_User",
                column: "UserInOrganizationId",
                principalTable: "Link_UserInOrganization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
