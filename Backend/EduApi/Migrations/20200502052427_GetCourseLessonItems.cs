using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetCourseLessonItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSqlFunctionAsTable("GetCourseLessonItems",
                @"SELECT ci.Id,  sbi.Name, sbi.Description FROM Edu_CourseItem AS ci
                  JOIN Shared_BasicInformation as sbi ON ci.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
                  WHERE ci.CourseLessonId = @CourseLessonId AND ci.IsDeleted = 0",
                new System.Collections.Generic.Dictionary<string, string>()
                {
                    {"@CourseLessonId", "uniqueidentifier"}
                }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
