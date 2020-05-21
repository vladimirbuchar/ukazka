using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCourseTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("CreateCourseTerm", new Core.DataTypes.InsertProcedureTableConfig()
            {
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>() {
                    { "@TimeFromId", "uniqueidentifier" },{ "@TimeToId", "uniqueidentifier" },{ "@ActiveFrom","datetime2"},
                    { "@ActiveTo","datetime2"},{ "@RegistrationFrom","datetime2"},{ "@RegistrationTo","datetime2"},
                    { "@Monday","bit"},{ "@Tuesday","bit"},{ "@Wednesday","bit"},{ "@Thursday","bit"},
                    { "@Friday","bit"},{ "@Saturday","bit"},{ "@Sunday","bit"},
                    { "@ClassRoomId", "uniqueidentifier" },
                    { "@CourseId", "uniqueidentifier" }

                },
                SaveBasicInformation = true,
                SaveStudentCount = true,
                SaveCoursePrice = true,
                TableName = "Edu_CourseTerm",

            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
