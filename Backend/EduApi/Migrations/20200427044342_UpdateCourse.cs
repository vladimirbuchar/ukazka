using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create  PROCEDURE UpdateCourse
@CourseTypeId uniqueidentifier 
,@CourseStatusId uniqueidentifier 
,@IsPrivateCourse bit 
,@CourseId uniqueidentifier
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max) 
,@CoursePrice float 
,@CoursePriceSale int 
,@StudentCountMinimumStudent int 
,@StudentCountMaximumStudent int 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = (SELECT BasicInformationId FROM Edu_course  WHERE Id =@CourseId)
DECLARE @CoursePriceId uniqueidentifier 
SET @CoursePriceId  = (SELECT CoursePriceId FROM Edu_course  WHERE Id =@CourseId)
DECLARE @StudentCountId uniqueidentifier 
SET @StudentCountId  = (SELECT StudentCountId FROM Edu_course  WHERE Id =@CourseId)

UPDATE Edu_Course SET CourseTypeId =@CourseTypeId, CourseStatusId=@CourseStatusId, IsPrivateCourse=@IsPrivateCourse WHERE Id=@CourseId
UPDATE Shared_BasicInformation SET Name =@BasicInformationName, Description =@BasicInformationDescription WHERE Id= @BasicInformationId
UPDATE Shared_CoursePrice SET Price =@CoursePrice, Sale =@CoursePriceSale WHERE Id= @CoursePriceId
UPDATE Shared_StudentCount SET MinimumStudent =@StudentCountMinimumStudent, MaximumStudent =@StudentCountMaximumStudent WHERE Id= @StudentCountId
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
