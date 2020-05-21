using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetCourseLessonDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSqlFunctionAsTable("GetCourseLessonDetail",
                                        @"SELECT cl.Id, sbi.Name, sbi.Description FROm Edu_CourseLesson AS cl
                                           JOIN Shared_BasicInformation as sbi ON cl.BasicInformationId =  sbi.Id AND sbi.IsDeleted = 0
WHERE cl.Id =@courseLessonId AND cl.IsDeleted = 0", new System.Collections.Generic.Dictionary<string, string>() { { "@courseLessonId", "uniqueidentifier" } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
