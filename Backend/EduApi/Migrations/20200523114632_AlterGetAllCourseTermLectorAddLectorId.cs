using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AlterGetAllCourseTermLectorAddLectorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllCourseTermLector](@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT uio.Id, p.FirstName, p.LastName,p.SecondName, l.Id AS lectorId FROM Link_CourseLector as l
                            join Link_UserInOrganization as uio ON l.UserInOrganizationId= uio.Id
                            join Edu_User as u ON uio.UserId = u.Id
                            join Edu_Person as p ON u.PersonId = p.Id
                           WHERE l.CourseTermId = @courseTermId AND l.IsDeleted = 0 AND uio.IsDeleted =0 
                            AND u.IsDeleted = 0 AND p.IsDeleted = 0	
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
