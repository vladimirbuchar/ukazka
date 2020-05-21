using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class BranchAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("CreateBranch", new Core.DataTypes.InsertProcedureTableConfig()
            {
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>() { { "@IsMainBranch", "bit" }, { "@OrganizationId", "uniqueidentifier" } },
                SaveBasicInformation = true,
                TableName = "Edu_Branch",
                SaveAddress = true
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
