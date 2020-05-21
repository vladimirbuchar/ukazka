using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetMyOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string query = @"SELECT o.Id, sbi.Name, eor.SystemIdentificator AS OrganizationRole
                             FROM Link_UserInOrganization AS luio
                             JOIN Edu_Organization AS o  ON o.Id = luio.OrganizationId
                             JOIN Shared_BasicInformation as sbi on o.BasicInformationId = sbi.Id
                             JOIN Edu_OrganizationRole as eor on luio.OrganizationRoleId = eor.Id
                             WHERE o.IsDeleted = 0 AND luio.IsDeleted = 0 AND eor.IsDeleted = 0  AND luio.UserId =@userId";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@userId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetMyOrganization", query, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSqlFunction("GetMyOrganization");
        }
    }
}
