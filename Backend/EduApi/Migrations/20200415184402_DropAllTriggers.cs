using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
namespace EduApi.Migrations
{
    public partial class DropAllTriggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<string> codeBooks = new List<string>()
            {
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
            foreach (string item in codeBooks)
            {
                migrationBuilder.DropTrigger(string.Format("SetIsDeleted_{0}", item));
                migrationBuilder.AddTriggerIsDeleted(item);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
