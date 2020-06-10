using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AlterGetCourseLessonItemDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetCourseLessonItemDetail](@CourseLessonItemId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ci.Id, ci.Html, sbi.Name, sbi.Description, ci.CourseLessonItemTemplateId FROM Edu_CourseLessonItem AS ci
                  JOIN Shared_BasicInformation as sbi ON ci.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
                  WHERE ci.Id = @CourseLessonItemId AND ci.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
