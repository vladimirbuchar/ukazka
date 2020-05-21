using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AlterGetStudentsInTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetStudentsInTerm](@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT cs.Id, p.FirstName, p.LastName,p.SecondName, cs.UserId AS StudentId
                            FROM Link_CourseStudent AS cs
							JOIN Link_UserInOrganization as luin ON  cs.UserId = luin.Id
                            JOIN Edu_User AS u ON luin.UserId = u.Id
                             JOIN Edu_Person AS p ON p.Id = u.PersonId
                            WHERE cs.CourseTermId = @courseTermId AND cs.IsDeleted = 0 AND u.IsDeleted = 0 
                            AND p.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
