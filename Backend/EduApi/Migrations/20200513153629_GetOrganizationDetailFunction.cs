using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationDetailFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION GetOrganizationDetail");
            migrationBuilder.Sql(@"CREATE FUNCTION GetOrganizationDetail(@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id,o.CanSendCourseInquiry,o.LicenseId, ci.Email,ci.PhoneNumber,ci.WWW,bi.Description,bi.Name
		                   FROM Edu_Organization AS o
		                   LEFT JOIN Shared_BasicInformation AS bi ON o.BasicInformationId = bi.Id AND bi.IsDeleted = 0 
		                   LEFT JOIN Shared_ContactInformation AS ci ON o.ContactInformationId = ci.Id AND ci.IsDeleted = 0
		                   WHERE o.Id = @organizationId AND o.IsDeleted= 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
