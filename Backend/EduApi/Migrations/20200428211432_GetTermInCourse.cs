using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetTermInCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT Id,CourseId,ActiveFrom,ActiveTo,RegistrationFrom,RegistrationTo,ClassRoomId,Monday,
                            Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,BasicInformationId,TimeFromId,
                            CoursePriceId,StudentCountId,TimeToId
                           FROM Edu_CourseTerm 
                           WHERE CourseId = @courseId AND IsDeleted =0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@courseId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetTermInCourse", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
