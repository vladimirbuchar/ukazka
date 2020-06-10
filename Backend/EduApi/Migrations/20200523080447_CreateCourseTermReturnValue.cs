using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateCourseTermReturnValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[CreateCourseTerm] 
@TimeFromId uniqueidentifier 
,@TimeToId uniqueidentifier 
,@ActiveFrom datetime2 
,@ActiveTo datetime2 
,@RegistrationFrom datetime2 
,@RegistrationTo datetime2 
,@Monday bit 
,@Tuesday bit 
,@Wednesday bit 
,@Thursday bit 
,@Friday bit 
,@Saturday bit 
,@Sunday bit 
,@ClassRoomId uniqueidentifier 
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
DECLARE @Edu_CourseTerm_id uniqueidentifier 
SET @Edu_CourseTerm_id  = NEWID() 
DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = NEWID(); 
INSERT INTO Shared_BasicInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Name,Description) VALUES 
(@BasicInformationId,0,0,1,null,@BasicInformationName,@BasicInformationDescription);
DECLARE @CoursePriceId uniqueidentifier 
SET @CoursePriceId  = NEWID(); 
INSERT INTO Shared_CoursePrice (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Price,Sale) VALUES 
(@CoursePriceId,0,0,1,null,@CoursePrice,@CoursePriceSale);
DECLARE @StudentCountId uniqueidentifier 
SET @StudentCountId  = NEWID(); 
INSERT INTO Shared_StudentCount (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,MinimumStudent,MaximumStudent) VALUES 
(@StudentCountId,0,0,1,null,@StudentCountMinimumStudent,@StudentCountMaximumStudent);
INSERT INTO Edu_CourseTerm 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, TimeFromId, TimeToId, ActiveFrom, ActiveTo, RegistrationFrom, RegistrationTo, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, ClassRoomId, CourseId, BasicInformationId, CoursePriceId, StudentCountId) VALUES 
(@Edu_CourseTerm_id, 0, 0, 1, null, @TimeFromId, @TimeToId, @ActiveFrom, @ActiveTo, @RegistrationFrom, @RegistrationTo, @Monday, @Tuesday, @Wednesday, @Thursday, @Friday, @Saturday, @Sunday, @ClassRoomId, @CourseId, @BasicInformationId, @CoursePriceId, @StudentCountId); 
SELECT @Edu_CourseTerm_id AS OutGuid
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
