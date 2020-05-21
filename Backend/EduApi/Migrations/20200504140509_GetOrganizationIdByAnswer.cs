using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationIdByAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE  FUNCTION GetOrganizationIdByAnswer(@answerId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                   FROM Edu_Organization AS o
                   JOIN Edu_BankOfQuestion AS boq ON o.Id = boq.OrganizationId
				   JOIN Edu_TestQuestion AS q on q.BankOfQuestionId = boq.Id
				   JOIN Edu_TestQuestionAnswer AS tqa on tqa.TestQuestionId = q.Id
                   WHERE tqa.Id = @answerId AND boq.IsDeleted = 0 AND o.IsDeleted = 0 AND q.IsDeleted  =0 AND tqa.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
