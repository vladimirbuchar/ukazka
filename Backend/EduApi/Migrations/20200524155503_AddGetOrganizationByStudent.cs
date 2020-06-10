using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddGetOrganizationByStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetOrganizationByStudent(@studentId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                           FROM Edu_Organization as o
                           JOIN Edu_Course as c ON o.Id = c.OrganizationId
                           JOIN Edu_CourseTerm as t ON c.Id = t.CourseId
						   JOIN Link_CourseStudent AS cs ON cs.CourseTermId = t.id
                           WHERE cs.Id = @studentId AND o.IsDeleted = 0 AND c.IsDeleted = 0 AND t.IsDeleted = 0
)

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
