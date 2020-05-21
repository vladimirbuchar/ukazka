using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AlterGetLicenseByOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetLicenseByOrganization](@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT l.Id, l.Name,l.Value,
                            l.IsDefault,l.MaximumBranch,l.MaximumUser,l.MaximumCourse,
                            l.MounthPrice,l.OneYearSale,l.SendCourseInquiry,
                            l.CreatePrivateCourse,l.Priority
                           FROM Cb_License AS l
                           JOIN Edu_Organization AS o ON l.Id = o.LicenseId
                           WHERE o.IsDeleted = 0 AND l.IsDeleted = 0 AND o.Id = @organizationId
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
