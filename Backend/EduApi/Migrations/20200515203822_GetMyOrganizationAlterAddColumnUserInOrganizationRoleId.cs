using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetMyOrganizationAlterAddColumnUserInOrganizationRoleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetMyOrganization](@userId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id, sbi.Name, eor.SystemIdentificator AS OrganizationRole, luio.Id AS UserInOrganizationRoleId
                             FROM Link_UserInOrganization AS luio
                             JOIN Edu_Organization AS o  ON o.Id = luio.OrganizationId
                             JOIN Shared_BasicInformation as sbi on o.BasicInformationId = sbi.Id
                             JOIN Edu_OrganizationRole as eor on luio.OrganizationRoleId = eor.Id
                             WHERE o.IsDeleted = 0 AND luio.IsDeleted = 0 AND eor.IsDeleted = 0  AND luio.UserId =@userId
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
