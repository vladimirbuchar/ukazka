using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateClassRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE UpdateClassRoom
@ClassRoomId uniqueidentifier ,
@Floor int 
,@MaxCapacity int 
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max) 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = (SELECT BasicInformationId FROM Edu_ClassRoom WHERE Id =@ClassRoomId) 
UPDATE Shared_BasicInformation SET Name = @BasicInformationName, Description = @BasicInformationDescription WHERE Id = @BasicInformationId
UPDATE Edu_ClassRoom SET Floor = @Floor, MaxCapacity =@MaxCapacity WHERE Id =@ClassRoomId

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
