using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class AddCourseProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("CreateCourse", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Edu_Course",
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>() {
                    { "@CourseTypeId", "uniqueidentifier" },
                    { "@CourseStatusId", "uniqueidentifier" },
                    { "@IsPrivateCourse", "bit" },
                    { "@OrganizationId", "uniqueidentifier" },
                },
                SaveBasicInformation = true,
                SaveCoursePrice = true,
                SaveStudentCount = true
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
