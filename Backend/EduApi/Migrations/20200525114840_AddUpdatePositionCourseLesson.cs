using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddUpdatePositionCourseLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE UpdatePositionCourseLesson
@CourseLessonId uniqueidentifier,
@NewPosition int

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
UPDATE Edu_CourseLesson SET Position = @NewPosition WHERE Id =@CourseLessonId
COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
