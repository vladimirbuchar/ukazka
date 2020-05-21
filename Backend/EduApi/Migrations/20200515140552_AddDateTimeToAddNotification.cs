using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddDateTimeToAddNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[AddNotification] 
@NotificationTypeId uniqueidentifier 
,@ObjectId uniqueidentifier 
,@UserId uniqueidentifier 
,@IsNew bit 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_Notification_id uniqueidentifier 
SET @Edu_Notification_id  = NEWID() 
INSERT INTO Edu_Notification 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, NotificationTypeId, ObjectId, UserId, IsNew,AddDate) VALUES 
(@Edu_Notification_id, 0, 0, 1, null, @NotificationTypeId, @ObjectId, @UserId, @IsNew,SYSDATETIME()); 

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
