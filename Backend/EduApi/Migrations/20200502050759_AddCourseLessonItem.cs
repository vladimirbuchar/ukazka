using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class AddCourseLessonItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("AddCourseLessonItem", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Edu_CourseItem",
                SaveBasicInformation = true,
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>()
                {
                    { "@Html", "varchar(max)" }, { "@CourseLessonId", "uniqueidentifier" }
                }
            });
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
