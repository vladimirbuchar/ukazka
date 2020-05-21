using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateBankOfQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("CreateBankOfQuestion", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Edu_BankOfQuestion",
                SaveBasicInformation = true,
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>()
                {
                    {"@OrganizationId","uniqueidentifier" }
                }
            });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
