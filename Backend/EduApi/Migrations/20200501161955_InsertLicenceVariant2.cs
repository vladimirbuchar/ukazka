using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class InsertLicenceVariant2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] columns = new string[]
            {
                "Id","IsDeleted","IsSystemObject","IsChanged","SystemIdentificator",
                "Name","Value","IsDefault","MaximumBranch","MaximumCourse","MounthPrice"
                ,"OneYearSale","SendCourseInquiry","CreatePrivateCourse"
                ,"Priority","MaximumUser","OneYearPrice"
            };



            object[] dataStandard = new object[]
            {
                Guid.NewGuid(),false,true,true,"STANDARD","STANDARD_LICENSE","STANDARD_LICENSE",true,25,25,199,5,false,false,3,250,0
            };

            migrationBuilder.InsertData("Cb_License", columns, dataStandard);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
