using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class InsertCourseType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<string> couserStatus = new List<string>
            {
                "ONLINE",
                "ATTENDANCE",
                "COMBINED"
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
                migrationBuilder.InsertData("Cb_CourseType", column, value);
                priority++;
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
