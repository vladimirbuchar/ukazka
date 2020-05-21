using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class RafactoringDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cb_GalleryItemType_Shared_Gallery_GalleryId",
                table: "Cb_GalleryItemType");

            migrationBuilder.DropForeignKey(
                name: "FK_Edu_User_System_ObjectHistory_ObjectHistoryId",
                table: "Edu_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Edu_User_Edu_UserRole_UserRoleId",
                table: "Edu_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Shared_ContactInformation_Edu_Organization_OrganizationId",
                table: "Shared_ContactInformation");

            migrationBuilder.DropIndex(
                name: "IX_Shared_ContactInformation_OrganizationId",
                table: "Shared_ContactInformation");

            migrationBuilder.DropIndex(
                name: "IX_Edu_User_ObjectHistoryId",
                table: "Edu_User");

            migrationBuilder.DropIndex(
                name: "IX_Edu_User_UserRoleId",
                table: "Edu_User");

            migrationBuilder.DropIndex(
                name: "IX_Cb_GalleryItemType_GalleryId",
                table: "Cb_GalleryItemType");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Shared_ContactInformation");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Shared_Address");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Link_UserInOrganization");

            migrationBuilder.DropColumn(
                name: "OrganizationRoleId",
                table: "Link_UserInOrganization");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Link_UserInOrganization");

            migrationBuilder.DropColumn(
                name: "ObjectHistoryId",
                table: "Edu_User");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Edu_User");

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "Cb_GalleryItemType");

            migrationBuilder.AlterColumn<Guid>(
                name: "GalleryItemTypeId",
                table: "Shared_Gallery",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Edu_UserRole",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContactInformationId",
                table: "Edu_Organization",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_System_ObjectHistory_UserId",
                table: "System_ObjectHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shared_Gallery_GalleryItemTypeId",
                table: "Shared_Gallery",
                column: "GalleryItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_UserRole_UserId",
                table: "Edu_UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Organization_ContactInformationId",
                table: "Edu_Organization",
                column: "ContactInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Organization_Shared_ContactInformation_ContactInformationId",
                table: "Edu_Organization",
                column: "ContactInformationId",
                principalTable: "Shared_ContactInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_UserRole_Edu_User_UserId",
                table: "Edu_UserRole",
                column: "UserId",
                principalTable: "Edu_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shared_Gallery_Cb_GalleryItemType_GalleryItemTypeId",
                table: "Shared_Gallery",
                column: "GalleryItemTypeId",
                principalTable: "Cb_GalleryItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_System_ObjectHistory_Edu_User_UserId",
                table: "System_ObjectHistory",
                column: "UserId",
                principalTable: "Edu_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Organization_Shared_ContactInformation_ContactInformationId",
                table: "Edu_Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Edu_UserRole_Edu_User_UserId",
                table: "Edu_UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Shared_Gallery_Cb_GalleryItemType_GalleryItemTypeId",
                table: "Shared_Gallery");

            migrationBuilder.DropForeignKey(
                name: "FK_System_ObjectHistory_Edu_User_UserId",
                table: "System_ObjectHistory");

            migrationBuilder.DropIndex(
                name: "IX_System_ObjectHistory_UserId",
                table: "System_ObjectHistory");

            migrationBuilder.DropIndex(
                name: "IX_Shared_Gallery_GalleryItemTypeId",
                table: "Shared_Gallery");

            migrationBuilder.DropIndex(
                name: "IX_Edu_UserRole_UserId",
                table: "Edu_UserRole");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Organization_ContactInformationId",
                table: "Edu_Organization");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Edu_UserRole");

            migrationBuilder.DropColumn(
                name: "ContactInformationId",
                table: "Edu_Organization");

            migrationBuilder.AlterColumn<Guid>(
                name: "GalleryItemTypeId",
                table: "Shared_Gallery",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Shared_ContactInformation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Shared_Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Link_UserInOrganization",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationRoleId",
                table: "Link_UserInOrganization",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Link_UserInOrganization",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ObjectHistoryId",
                table: "Edu_User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserRoleId",
                table: "Edu_User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GalleryId",
                table: "Cb_GalleryItemType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shared_ContactInformation_OrganizationId",
                table: "Shared_ContactInformation",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_User_ObjectHistoryId",
                table: "Edu_User",
                column: "ObjectHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_User_UserRoleId",
                table: "Edu_User",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_GalleryItemType_GalleryId",
                table: "Cb_GalleryItemType",
                column: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cb_GalleryItemType_Shared_Gallery_GalleryId",
                table: "Cb_GalleryItemType",
                column: "GalleryId",
                principalTable: "Shared_Gallery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_User_System_ObjectHistory_ObjectHistoryId",
                table: "Edu_User",
                column: "ObjectHistoryId",
                principalTable: "System_ObjectHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_User_Edu_UserRole_UserRoleId",
                table: "Edu_User",
                column: "UserRoleId",
                principalTable: "Edu_UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shared_ContactInformation_Edu_Organization_OrganizationId",
                table: "Shared_ContactInformation",
                column: "OrganizationId",
                principalTable: "Edu_Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
