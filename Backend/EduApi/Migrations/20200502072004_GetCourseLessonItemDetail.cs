using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetCourseLessonItemDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSqlFunctionAsTable("GetCourseLessonItemDetail",
                   @"SELECT ci.Id, ci.Html, sbi.Name, sbi.Description FROM Edu_CourseItem AS ci
                  JOIN Shared_BasicInformation as sbi ON ci.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
                  WHERE ci.Id = @CourseLessonItemId AND ci.IsDeleted = 0",
                   new System.Collections.Generic.Dictionary<string, string>()
                   {
                    {"@CourseLessonItemId", "uniqueidentifier"}
                   }
                   );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
