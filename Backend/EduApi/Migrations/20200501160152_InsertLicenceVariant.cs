using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class InsertLicenceVariant : Migration
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
            object[] dataFree = new object[]
            {
                Guid.NewGuid(),false,true,true,"FREE","FREE_LICENSE","FREE_LICENSE",true,1,25,0,0,false,false,4,25,0
            };
            migrationBuilder.UpdateData("Cb_License", columns, dataFree, "SystemIdentificator", "FREE_LICENSE");

            object[] dataStandard = new object[]
            {
                Guid.NewGuid(),false,true,true,"STANDARD","STANDARD_LICENSE","STANDARD_LICENSE",true,25,25,199,5,false,false,3,250,0
            };
            object[] dataPrefesional = new object[]
            {
                Guid.NewGuid(),false,true,true,"PROFESIONAL","PROFESIONAL_LICENSE","PROFESIONAL_LICENSE",true,100,25,399,10,false,false,2,1000,0
            };
            migrationBuilder.InsertData("Cb_License", columns, dataPrefesional);

            object[] dataEnterprise = new object[]
            {
                Guid.NewGuid(),false,true,true,"ENTERPRISE","ENTERPRISE_LICENSE","ENTERPRISEL_LICENSE",true,-1,-1,699,15,false,false,1,-1,0
            };
            migrationBuilder.InsertData("Cb_License", columns, dataEnterprise);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
