using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class InsertUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<string> list = new List<string>
            {
                "REGISTERED_USER",
                "SYSTEM",
                "ADMINISTRATOR",
                "ANONYMOUS"
            };
            List<string> userRoles = list;
            string[] sbi = new string[]
                {
                    "Id","IsDeleted","IsSystemObject","IsChanged","SystemIdentificator","Name","Description"
                };
            string[] eduRole = new string[]
                {
                    "Id","IsDeleted","IsSystemObject","IsChanged","SystemIdentificator","BasicInformationId"
                };
            foreach (string userRole in userRoles)
            {
                Guid userRoleGuid = Guid.NewGuid();

                object[] sbivalue = new object[]
                {
                    userRoleGuid,false,true,true,Guid.NewGuid().ToString(),"",""
                };
                migrationBuilder.InsertData("Shared_BasicInformation", sbi, sbivalue);


                object[] eduRoleValue = new object[]
                {
                    Guid.NewGuid(),false,true,true,userRole,userRoleGuid
                };
                migrationBuilder.InsertData("Edu_UserRole", eduRole, eduRoleValue);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
