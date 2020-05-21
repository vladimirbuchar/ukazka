using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetAllUserInOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT uio.Id, p.FirstName, p.SecondName, p.LastName
                             FROM Edu_User AS u
                             JOIN Edu_Person as p ON u.PersonId = p.Id
                             JOIN Link_UserInOrganization AS uio ON uio.UserId = u.Id
                             JOIN Edu_OrganizationRole AS orl ON orl.Id = uio.OrganizationRoleId
                             WHERE uio.OrganizationId= @organizationOid 
                                     AND  u.IsDeleted = 0 AND p.IsDeleted =0 AND uio.IsDeleted = 0 AND orl.IsDeleted= 0 ";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@organizationOid", "uniqueidentifier" }

            };
            migrationBuilder.CreateSqlFunctionAsTable("GetAllUserInOrganization", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
