using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class GetQuestionInBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSqlFunctionAsTable("GetQuestionInBank",
                @"SELECT tq.Id, tq.Question, tq.AnswerModeId FROM Edu_TestQuestion AS tq
                  WHERE tq.BankOfQuestionId = @BankOfQuestionId and tq.IsDeleted= 0 ",
                new System.Collections.Generic.Dictionary<string, string>()
                {
                    {"@BankOfQuestionId","uniqueidentifier" }
                }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
