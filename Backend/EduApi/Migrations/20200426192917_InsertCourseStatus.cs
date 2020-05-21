using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class InsertCourseStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<string> couserStatus = new List<string>
            {
                "NEW",
                "IN_PREPARATION",
                "OPEN",
                "ONGOING",
                "CLOSED"
            };
            string[] column = new string[]
            {
                "Id","IsDeleted" ,"IsSystemObject","IsChanged","SystemIdentificator","Name","Value","IsDefault","Priority"
            };
            int priority = 1;
            foreach (string item in couserStatus)
            {
                object[] value = new object[]
                {
                    Guid.NewGuid() ,false,true,true,item,item,item,false,priority
                };
                migrationBuilder.InsertData("Cb_CourseStatus", column, value);
                priority++;
            }

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
