using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetCourseTermDetailAddBranchId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetCourseTermDetail](@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ct.Id, ct.ActiveFrom,ct.ActiveTo,ct.RegistrationFrom,ct.RegistrationTo, 
                                ct.ClassRoomId,ct.Monday,ct.Tuesday, ct.Wednesday, ct.Thursday, ct.Friday, ct.Saturday,
                                ct.Sunday, bi.Name,bi.Description,ct.TimeFromId,tf.Value AS TimeFromValue, ct.TimeToId,
                                tt.Value AS TimeToValue,ct.CoursePriceId,cp.Price,cp.Sale,ct.StudentCountId, 
                                sc.MaximumStudent,sc.MinimumStudent, cl.BranchId
                            FROM Edu_CourseTerm AS ct
                            JOIN Shared_BasicInformation AS bi ON ct.BasicInformationId = bi.Id
                            JOIN Cb_TimeTable AS tf ON ct.TimeFromId = tf.Id
                            JOIN Cb_TimeTable AS tt ON ct.TimeToId = tt.Id
                            JOIN Shared_CoursePrice AS cp ON ct.CoursePriceId = cp.Id
                            JOIN Shared_StudentCount AS sc ON ct.StudentCountId = sc.Id
							JOIN Edu_ClassRoom AS cl ON cl.Id = ct.ClassRoomId
                            WHERE ct.Id = @courseTermId  AND ct.IsDeleted =0 AND bi.IsDeleted= 0 AND tf.IsDeleted = 0 
                                    AND tt.IsDeleted= 0 AND cp.IsDeleted = 0 AND sc.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
