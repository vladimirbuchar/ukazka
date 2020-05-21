using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateCourseTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE  PROCEDURE UpdateCourseTerm
@Id uniqueidentifier,
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
SET @BasicInformationId  = (SELECT BasicInformationId FROM Edu_CourseTerm  Where Id= @Id AND IsDeleted = 0)
DECLARE @CoursePriceId uniqueidentifier 
SET @CoursePriceId  = (SELECT CoursePriceId FROM Edu_CourseTerm  Where Id= @Id AND IsDeleted = 0)
DECLARE @StudentCountId uniqueidentifier 
SET @StudentCountId  = (SELECT StudentCountId FROM Edu_CourseTerm  Where Id= @Id AND IsDeleted = 0)

Update Shared_BasicInformation SET Name = @BasicInformationName, Description = @BasicInformationDescription WHERE Id = @BasicInformationId
Update Shared_CoursePrice SET Price = @CoursePrice, Sale = @CoursePriceSale WHERE Id = @CoursePriceId
Update Shared_StudentCount SET MinimumStudent =@StudentCountMinimumStudent, MaximumStudent = @StudentCountMaximumStudent  WHERE Id = @StudentCountId
UPDATE Edu_CourseTerm  SET 
TimeFromId = @TimeFromId, 
TimeToId = @TimeToId, 
ActiveFrom = @ActiveFrom, 
ActiveTo = @ActiveTo, 
RegistrationFrom = @RegistrationFrom, 
RegistrationTo = @RegistrationTo, 
Monday = @Monday, 
Tuesday = @Tuesday, Wednesday = @Wednesday, 
Thursday = @Thursday, Friday = @Friday, Saturday = @Saturday, Sunday =@Sunday
 
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
