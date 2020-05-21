using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class GetOrganizationByCourseLessonItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSqlFunctionAsTable("GetOrganizationByCourseLessonItem",
                @"SELECT o.Id
                   FROM Edu_Organization AS o
                   JOIN Edu_Course AS c ON o.Id = c.OrganizationId
                   JOIN Edu_CourseLesson AS cl  ON  c.Id  = cl.CourseId
                   JOIN Edu_CourseItem AS ci ON cl.Id = ci.CourseLessonId
                   WHERE ci.Id = @courseLessonItemId AND c.IsDeleted = 0 AND o.IsDeleted = 0 AND ci.IsDeleted = 0",
                new System.Collections.Generic.Dictionary<string, string>()
                {
                    {"@courseLessonItemId","uniqueidentifier" }
                }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
