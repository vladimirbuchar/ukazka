using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class AddQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("AddQuestion", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Edu_TestQuestion",
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>()
                {
                    { "@Question","nvarchar(max)" },
                    { "@AnswerMode","nvarchar(max)" },
                    { "@BankOfQuestionId","uniqueidentifier" },

                }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
