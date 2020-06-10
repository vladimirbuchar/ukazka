using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddReferenceToCourseItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseLessonItemTemplateId",
                table: "Edu_CourseItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseItem_CourseLessonItemTemplateId",
                table: "Edu_CourseItem",
                column: "CourseLessonItemTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseItem_Cb_CourseLessonItemTemplate_CourseLessonItemTemplateId",
                table: "Edu_CourseItem",
                column: "CourseLessonItemTemplateId",
                principalTable: "Cb_CourseLessonItemTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseItem_Cb_CourseLessonItemTemplate_CourseLessonItemTemplateId",
                table: "Edu_CourseItem");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseItem_CourseLessonItemTemplateId",
                table: "Edu_CourseItem");

            migrationBuilder.DropColumn(
                name: "CourseLessonItemTemplateId",
                table: "Edu_CourseItem");
        }
    }
}
