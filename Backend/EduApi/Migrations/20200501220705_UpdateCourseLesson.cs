using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateCourseLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE UpdateCourseLesson
@CourseLessonId uniqueidentifier 
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max) 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = (SELECT BasicInformationId FROM Edu_CourseLesson WHERE Id =@CourseLessonId AND IsDeleted = 0)
UPDATE Shared_BasicInformation SET Name = @BasicInformationName, Description =@BasicInformationDescription WHERE Id =@BasicInformationId
COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END 
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
