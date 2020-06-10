using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AlterAddCourseLessonItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE AddCourseLessonItem
@Html varchar(max) 
,@CourseLessonId uniqueidentifier 
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max) 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_CourseItem_id uniqueidentifier 
SET @Edu_CourseItem_id  = NEWID() 
DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = NEWID(); 
INSERT INTO Shared_BasicInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Name,Description) VALUES 
(@BasicInformationId,0,0,1,null,@BasicInformationName,@BasicInformationDescription);
INSERT INTO Edu_CourseLessonItem 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, Html, CourseLessonId, BasicInformationId) VALUES 
(@Edu_CourseItem_id, 0, 0, 1, null, @Html, @CourseLessonId, @BasicInformationId); 

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
