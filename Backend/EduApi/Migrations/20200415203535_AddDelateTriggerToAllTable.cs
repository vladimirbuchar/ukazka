using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class AddDelateTriggerToAllTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<string> tables = new List<string>()
            {
                "Edu_Branch","Edu_Category","Edu_ClassRoom","Edu_Course","Edu_CourseItem","Edu_CourseLesson","Edu_CourseRate",
                "Edu_CourseTerm","Edu_CourseTest","Edu_Inquiry","Edu_Job","Edu_LectorRate","Edu_Organization",
                "Edu_OrganizationRole","Edu_OrganizationRolePermition","Edu_Person","Edu_Slider","Edu_StudentTestSummary",
                "Edu_TestQuestion","Edu_TestQuestionAnswer","Edu_TestStudentResult","Edu_User","Edu_UserRole",


            };
            foreach (string item in tables)
            {
                migrationBuilder.AddTriggerIsDeleted(item);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
