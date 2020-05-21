using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("AddAnswer", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Edu_TestQuestionAnswer",
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>()
                {
                    { "@Answer","nvarchar(max)" },
                    { "@IsTrueAnswer","bit" },
                    { "@TestQuestionId","uniqueidentifier" }
            }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
