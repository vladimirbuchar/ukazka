using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class InsertTimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            int priority = 1;
            string[] columns = new string[]
            {
                "Id","IsDeleted","IsSystemObject","IsChanged","SystemIdentificator","Name","Value","IsDefault","Priority"
            };
            for (int h = 0; h <= 23; h++)
            {
                for (int m = 0; m <= 55; m += 5)
                {
                    string timeformat;
                    if (h < 9 && m < 9)
                    {
                        timeformat = string.Format("0{0}:0{1}:00", h, m);
                    }
                    else if (h < 9)
                    {
                        timeformat = string.Format("0{0}:{1}:00", h, m);
                    }
                    else if (m < 9)
                    {
                        timeformat = string.Format("{0}:0{1}:00", h, m);
                    }
                    else
                    {
                        timeformat = string.Format("{0}:{1}:00", h, m);
                    }
                    object[] value = new object[]
                    {
                        Guid.NewGuid() ,false,true,true,Guid.NewGuid().ToString(),timeformat,timeformat,false,priority
                    };
                    migrationBuilder.InsertData("Cb_TimeTable", columns, value);
                    priority++;
                }
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
