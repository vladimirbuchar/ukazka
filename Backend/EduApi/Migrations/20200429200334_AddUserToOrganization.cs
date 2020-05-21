using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddUserToOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("AddUserToOrganization", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Link_UserInOrganization",
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>() { { "@OrganizationId", "uniqueidentifier" },
                { "@OrganizationRoleId", "uniqueidentifier" }, { "@UserId", "uniqueidentifier" },
                }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
