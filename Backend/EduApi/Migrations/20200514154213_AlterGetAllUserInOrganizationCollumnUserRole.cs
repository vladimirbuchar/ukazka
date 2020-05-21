using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AlterGetAllUserInOrganizationCollumnUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllUserInOrganization](@organizationOid uniqueidentifier)
RETURNS TABLE  AS
RETURN 
(  
SELECT uio.Id, p.FirstName, p.SecondName, p.LastName, u.UserEmail, orl.SystemIdentificator AS UserRole
                             FROM Edu_User AS u
                             JOIN Edu_Person as p ON u.PersonId = p.Id
                             JOIN Link_UserInOrganization AS uio ON uio.UserId = u.Id
                             JOIN Edu_OrganizationRole AS orl ON orl.Id = uio.OrganizationRoleId
                             WHERE uio.OrganizationId= @organizationOid 
                                     AND  u.IsDeleted = 0 AND p.IsDeleted =0 AND uio.IsDeleted = 0 AND orl.IsDeleted= 0 
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
