using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class GetOrganizationByCourseLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSqlFunctionAsTable("GetOrganizationByCourseLesson", @"SELECT o.Id
                                  FROM Edu_Organization AS o
                            JOIN Edu_Course AS c ON o.Id = c.OrganizationId
							JOIN Edu_CourseLesson AS cl  ON  c.Id  = cl.CourseId
                            WHERE cl.Id = @courseLessonId AND c.IsDeleted = 0 AND o.IsDeleted = 0 ",
                            new System.Collections.Generic.Dictionary<string, string>() { { "@courseLessonId", "uniqueidentifier" } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
