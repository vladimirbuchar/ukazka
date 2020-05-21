using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAnswerDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSqlFunctionAsTable("GetAnswerDetail", @"SELECT tqa.Id, tqa.Answer, tqa.IsTrueAnswer FROM Edu_TestQuestionAnswer AS tqa
                WHERE tqa.Id = @answerId AND tqa.IsDeleted = 0",
                new System.Collections.Generic.Dictionary<string, string>()
                {
                    {"@answerId","uniqueidentifier" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
