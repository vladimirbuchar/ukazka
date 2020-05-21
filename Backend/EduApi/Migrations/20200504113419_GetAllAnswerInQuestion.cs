using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class GetAllAnswerInQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSqlFunctionAsTable("GetAllAnswerInQuestion",
                @"SELECT tqa.Id, tqa.Answer, tqa.IsTrueAnswer FROM Edu_TestQuestionAnswer AS tqa
                WHERE tqa.TestQuestionId = @TestQuestionId AND tqa.IsDeleted = 0",
                new System.Collections.Generic.Dictionary<string, string>()
                {
                    { "@TestQuestionId","uniqueidentifier"}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
