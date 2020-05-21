using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class RefactorTriggerDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<string> tables = new List<string>()
            {
                "Edu_Branch","Edu_Category","Edu_ClassRoom","Edu_Course","Edu_CourseItem","Edu_CourseLesson","Edu_CourseRate",
                "Edu_CourseTerm","Edu_CourseTest","Edu_Inquiry","Edu_Job","Edu_LectorRate","Edu_Organization",
                "Edu_OrganizationRole","Edu_OrganizationRolePermition","Edu_Person","Edu_Slider","Edu_StudentTestSummary",
                "Edu_TestQuestion","Edu_TestQuestionAnswer","Edu_TestStudentResult","Edu_User","Edu_UserRole",
                "Link_CourseCategory","Link_CourseLector","Link_CourseStudent","Shared_ContactInformation","Shared_CoursePrice",
               "Link_UserInOrganization","Link_UserInRole","Shared_Address","Shared_BasicInformation","Shared_Gallery",
               "Shared_StudentCount","System_DataMigration","System_ObjectHistory",
                "Cb_AddressType",
                "Cb_Country",
                "Cb_CourseStatus",
                "Cb_CourseType",
                "Cb_Culture",
                "Cb_Email",
                "Cb_GalleryItemType",
                "Cb_License",
                "Cb_TimeTable"


            };
            foreach (string item in tables)
            {
                migrationBuilder.DropTrigger($"SetIsDeleted_{item}");
                migrationBuilder.AddTriggerIsDeleted(item);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
