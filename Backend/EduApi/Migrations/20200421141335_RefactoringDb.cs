using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class RefactoringDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Category_Link_CourseCategory_CourseCategoryId",
                table: "Edu_Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Course_Link_CourseCategory_CourseCategoryId",
                table: "Edu_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTerm_Link_CourseLector_CourseLectorId",
                table: "Edu_CourseTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_UserInOrganization_Link_CourseLector_CourseLectorId",
                table: "Link_UserInOrganization");

            migrationBuilder.DropIndex(
                name: "IX_Link_UserInOrganization_CourseLectorId",
                table: "Link_UserInOrganization");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTerm_CourseLectorId",
                table: "Edu_CourseTerm");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Course_CourseCategoryId",
                table: "Edu_Course");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Category_CourseCategoryId",
                table: "Edu_Category");

            migrationBuilder.DropColumn(
                name: "CourseLectorId",
                table: "Link_UserInOrganization");

            migrationBuilder.DropColumn(
                name: "CourseLectorId",
                table: "Edu_CourseTerm");

            migrationBuilder.DropColumn(
                name: "CourseCategoryId",
                table: "Edu_Course");

            migrationBuilder.DropColumn(
                name: "CourseCategoryId",
                table: "Edu_Category");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseTermId",
                table: "Link_CourseLector",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserInOrganizationId",
                table: "Link_CourseLector",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Link_CourseCategory",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Link_CourseCategory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseLector_CourseTermId",
                table: "Link_CourseLector",
                column: "CourseTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseLector_UserInOrganizationId",
                table: "Link_CourseLector",
                column: "UserInOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseCategory_CategoryId",
                table: "Link_CourseCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseCategory_CourseId",
                table: "Link_CourseCategory",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_CourseCategory_Edu_Category_CategoryId",
                table: "Link_CourseCategory",
                column: "CategoryId",
                principalTable: "Edu_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_CourseCategory_Edu_Course_CourseId",
                table: "Link_CourseCategory",
                column: "CourseId",
                principalTable: "Edu_Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_CourseLector_Edu_CourseTerm_CourseTermId",
                table: "Link_CourseLector",
                column: "CourseTermId",
                principalTable: "Edu_CourseTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_CourseLector_Link_UserInOrganization_UserInOrganizationId",
                table: "Link_CourseLector",
                column: "UserInOrganizationId",
                principalTable: "Link_UserInOrganization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_CourseCategory_Edu_Category_CategoryId",
                table: "Link_CourseCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_CourseCategory_Edu_Course_CourseId",
                table: "Link_CourseCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_CourseLector_Edu_CourseTerm_CourseTermId",
                table: "Link_CourseLector");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_CourseLector_Link_UserInOrganization_UserInOrganizationId",
                table: "Link_CourseLector");

            migrationBuilder.DropIndex(
                name: "IX_Link_CourseLector_CourseTermId",
                table: "Link_CourseLector");

            migrationBuilder.DropIndex(
                name: "IX_Link_CourseLector_UserInOrganizationId",
                table: "Link_CourseLector");

            migrationBuilder.DropIndex(
                name: "IX_Link_CourseCategory_CategoryId",
                table: "Link_CourseCategory");

            migrationBuilder.DropIndex(
                name: "IX_Link_CourseCategory_CourseId",
                table: "Link_CourseCategory");

            migrationBuilder.DropColumn(
                name: "CourseTermId",
                table: "Link_CourseLector");

            migrationBuilder.DropColumn(
                name: "UserInOrganizationId",
                table: "Link_CourseLector");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Link_CourseCategory");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Link_CourseCategory");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseLectorId",
                table: "Link_UserInOrganization",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseLectorId",
                table: "Edu_CourseTerm",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseCategoryId",
                table: "Edu_Course",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseCategoryId",
                table: "Edu_Category",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Link_UserInOrganization_CourseLectorId",
                table: "Link_UserInOrganization",
                column: "CourseLectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_CourseLectorId",
                table: "Edu_CourseTerm",
                column: "CourseLectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Course_CourseCategoryId",
                table: "Edu_Course",
                column: "CourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Category_CourseCategoryId",
                table: "Edu_Category",
                column: "CourseCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Category_Link_CourseCategory_CourseCategoryId",
                table: "Edu_Category",
                column: "CourseCategoryId",
                principalTable: "Link_CourseCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Course_Link_CourseCategory_CourseCategoryId",
                table: "Edu_Course",
                column: "CourseCategoryId",
                principalTable: "Link_CourseCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTerm_Link_CourseLector_CourseLectorId",
                table: "Edu_CourseTerm",
                column: "CourseLectorId",
                principalTable: "Link_CourseLector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_UserInOrganization_Link_CourseLector_CourseLectorId",
                table: "Link_UserInOrganization",
                column: "CourseLectorId",
                principalTable: "Link_CourseLector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
