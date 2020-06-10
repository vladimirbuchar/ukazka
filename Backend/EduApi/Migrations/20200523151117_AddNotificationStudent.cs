using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddNotificationStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] column = new string[]
            {
                "Id","IsDeleted","IsSystemObject","IsChanged","SystemIdentificator","Name","Value","IsDefault","Priority"
            };
            object[] values = new object[]
            {
                Guid.NewGuid(),false,true,true,"ADD_STUDENT_TO_COURSE_TERM","ADD_STUDENT_TO_COURSE_TERM","ADD_STUDENT_TO_COURSE_TERM",false,0
            };
            migrationBuilder.InsertData("Cb_NotificationType", column, values);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
