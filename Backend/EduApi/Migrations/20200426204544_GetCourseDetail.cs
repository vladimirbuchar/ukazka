using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetCourseDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT c.Id,c.IsPrivateCourse, bi.Name, bi.Description, cp.Price, cp.Sale,
                                  c.CourseStatusId,c.CourseTypeId  FROM Edu_Course AS c
                            JOIN Shared_BasicInformation AS bi ON c.BasicInformationId = bi.Id
                            JOIN Shared_CoursePrice AS cp ON c.CoursePriceId = cp.Id
                            JOIN Shared_StudentCount AS sc ON c.StudentCountId = sc.Id 
                        WHERE c.Id = @courseId AND c.IsDeleted = 0 AND bi.IsDeleted = 0 AND cp.IsDeleted = 0 
                                AND sc.IsDeleted = 0 
                                ";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@courseId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetCourseDetail", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
