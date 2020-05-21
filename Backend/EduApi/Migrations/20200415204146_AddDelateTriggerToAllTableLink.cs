using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class AddDelateTriggerToAllTableLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<string> tables = new List<string>()
            {
               "Link_CourseCategory","Link_CourseLector","Link_CourseStudent","Shared_ContactInformation","Shared_CoursePrice",
               "Link_UserInOrganization","Link_UserInRole","Shared_Address","Shared_BasicInformation","Shared_Gallery",
               "Shared_StudentCount"
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
