using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class InsertFreeLicense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] columns = new string[]
            {
                "Id","IsDeleted","IsSystemObject","IsChanged","SystemIdentificator","Name","Value","IsDefault"
                ,"MaximumStudents","MaximumBranch","MaximumLectors","MaximumCourse","MounthPrice"
                ,"OneYearSale","OneYearPrice","Support","SendCourseInquiry","CreatePrivateCourse"
                ,"Priority"
            };
            object[] data = new object[]
            {
                Guid.NewGuid(),false,true,true,"FREE","FREE_LICENSE","FREE_LICENSE",true,10,10,10,10
                ,false,false,false,false,false,false,3
            };
            migrationBuilder.InsertData("Cb_License", columns, data);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Cb_License", "Identificator", "FREE");
        }
    }
}
