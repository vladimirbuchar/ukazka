using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCourseLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("AddCourseLesson", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Edu_CourseLesson",
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>() { { "@CourseId", "uniqueidentifier" } },
                SaveBasicInformation = true
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
