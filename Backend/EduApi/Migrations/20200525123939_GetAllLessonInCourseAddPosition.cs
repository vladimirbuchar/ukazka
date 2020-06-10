using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllLessonInCourseAddPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllLessonInCourse](@courseId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT cl.Id, sbi.Name, sbi.Description,cl.Position FROm Edu_CourseLesson AS cl
                             JOIN Shared_BasicInformation as sbi ON cl.BasicInformationId =  sbi.Id AND sbi.IsDeleted = 0
                             WHERE cl.CourseId =@courseId AND cl.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
