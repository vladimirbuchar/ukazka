using Core.DataTypes;
using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

namespace EduApi.Migrations
{
    public partial class AddOrganizationInsertProcedureUserInRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSqlProcedure("CreateOrganization");
            CustomInsert customInsert = new CustomInsert
            {
                TableName = "Link_UserInOrganization"
            };
            customInsert.Columns.Add(new QueryColumn() { ColumnName = "OrganizationId", ColumnValue = "@Edu_Organization_id" });
            customInsert.Columns.Add(new QueryColumn() { ColumnName = "OrganizationRoleId", ColumnValue = "@OrganizationRoleId" });
            customInsert.Columns.Add(new QueryColumn() { ColumnName = "UserId", ColumnValue = "@UserId" });
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DECLARE @OrganizationRoleId uniqueidentifier");
            sb.AppendLine("SET @OrganizationRoleId = (SELECT Id FROM Edu_OrganizationRole WHERE SystemIdentificator = @OrganizationRoleIdentificator AND IsDeleted = 0) ");
            customInsert.BeforeQuery.Add(sb.ToString());

            migrationBuilder.CreateInsertProcedure("CreateOrganization", new InsertProcedureTableConfig()
            {
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>() { { "@CanSendCourseInquiry", "bit" }, { "@LicenseId", "uniqueidentifier" } },
                SaveBasicInformation = true,
                TableName = "Edu_Organization",
                SaveContactInformation = true,
                CustomProcedureParametrs = new System.Collections.Generic.Dictionary<string, string>() { { "@UserId", "uniqueidentifier" }, { "@OrganizationRoleIdentificator", "varchar(max)" } }

            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
