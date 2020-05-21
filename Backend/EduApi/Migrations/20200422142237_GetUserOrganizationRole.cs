using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetUserOrganizationRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSqlFunction("GetUserOrganizationRole");
            string sql = @"SELECT eor.Id, eor.SystemIdentificator
                           FROM Link_UserInOrganization AS uio
                           JOIN Edu_OrganizationRole AS eor ON uio.OrganizationRoleId = eor.Id
                           WHERE uio.IsDeleted = 0 AND eor.IsDeleted = 0 and uio.OrganizationId = @organizationId 
                                AND uio.UserId =@userId ";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@userId", "uniqueidentifier" },
                { "@organizationId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetUserOrganizationRole", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
