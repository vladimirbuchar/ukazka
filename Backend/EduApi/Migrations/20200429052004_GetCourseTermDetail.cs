using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetCourseTermDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT ct.Id, ct.ActiveFrom,ct.ActiveTo,ct.RegistrationFrom,ct.RegistrationTo, 
                                ct.ClassRoomId,ct.Monday,ct.Tuesday, ct.Wednesday, ct.Thursday, ct.Friday, ct.Saturday,
                                ct.Sunday, bi.Name,bi.Description,ct.TimeFromId,tf.Value AS TimeFromValue, ct.TimeToId,
                                tt.Value AS TimeToValue,ct.CoursePriceId,cp.Price,cp.Sale,ct.StudentCountId, 
                                sc.MaximumStudent,sc.MinimumStudent
                            FROM Edu_CourseTerm AS ct
                            JOIN Shared_BasicInformation AS bi ON ct.BasicInformationId = bi.Id
                            JOIN Cb_TimeTable AS tf ON ct.TimeFromId = tf.Id
                            JOIN Cb_TimeTable AS tt ON ct.TimeToId = tt.Id
                            JOIN Shared_CoursePrice AS cp ON ct.CoursePriceId = cp.Id
                            JOIN Shared_StudentCount AS sc ON ct.StudentCountId = sc.Id
                            WHERE ct.Id = @courseTermId  AND ct.IsDeleted =0 AND bi.IsDeleted= 0 AND tf.IsDeleted = 0 
                                    AND tt.IsDeleted= 0 AND cp.IsDeleted = 0 AND sc.IsDeleted = 0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@courseTermId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetCourseTermDetail", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
