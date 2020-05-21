using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GHetAllLessonInCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string query = @"SELECT cl.Id, sbi.Name, sbi.Description FROm Edu_CourseLesson AS cl
                             JOIN Shared_BasicInformation as sbi ON cl.BasicInformationId =  sbi.Id AND sbi.IsDeleted = 0
                             WHERE cl.CourseId =@courseId AND cl.IsDeleted = 0";
            migrationBuilder.CreateSqlFunctionAsTable("GetAllLessonInCourse", query, new System.Collections.Generic.Dictionary<string, string>()
            {
                { "courseId","uniqueidentifier"}
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
