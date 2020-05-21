using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetUserOrganizationRoleDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Dictionary<string, string> sqlParameters = new Dictionary<string, string>
            {
                { "@userInOrganizationId", "uniqueidentifier" }
            };

            migrationBuilder.CreateSqlFunctionAsTable("GetUserOrganizationRoleDetail", @"SELECT  OrganizationRoleId
  FROM Link_UserInOrganization WHERE Id = @userInOrganizationId", sqlParameters);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
