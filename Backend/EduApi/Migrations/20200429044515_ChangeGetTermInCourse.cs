using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ChangeGetTermInCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION GetTermInCourse(@courseId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT t.Id,t.CourseId,t.ActiveFrom,t.ActiveTo,t.RegistrationFrom,t.RegistrationTo,t.ClassRoomId,t.Monday,
                            t.Tuesday,t.Wednesday,t.Thursday,t.Friday,t.Saturday,t.Sunday,bi.Name, bi.Description,t.TimeFromId,
                            p.Price, p.Sale,sc.MaximumStudent, sc.MinimumStudent,TimeToId
                           FROM Edu_CourseTerm AS t
						   LEFT JOIN Shared_BasicInformation AS bi ON  t.BasicInformationId =  bi.Id AND bi.IsDeleted = 0
						   LEFT JOIN Shared_CoursePrice as p on t.CoursePriceId = p.Id AND p.IsDeleted = 0
						   LEFT JOIN Shared_StudentCount as sc ON t.StudentCountId = sc.Id and sc.IsDeleted =0
                           WHERE t.CourseId = @courseId AND t.IsDeleted =0
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
