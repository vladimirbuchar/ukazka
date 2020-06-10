using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AlterGetOrganizationByCourseLessonItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetOrganizationByCourseLessonItem](@courseLessonItemId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                   FROM Edu_Organization AS o
                   JOIN Edu_Course AS c ON o.Id = c.OrganizationId
                   JOIN Edu_CourseLesson AS cl  ON  c.Id  = cl.CourseId
                   JOIN Edu_CourseLessonItem AS ci ON cl.Id = ci.CourseLessonId
                   WHERE ci.Id = @courseLessonItemId AND c.IsDeleted = 0 AND o.IsDeleted = 0 AND ci.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
