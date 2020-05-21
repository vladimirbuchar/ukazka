using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetMyNotificationAlterFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetMyNotification](@userId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT n.Id,nt.SystemIdentificator AS NotificationIdentificator ,n.ObjectId,n.IsNew,n.AddDate FROM Edu_Notification  AS n
JOIN Cb_NotificationType AS nt ON n.NotificationTypeId = nt.Id
WHERE n.UserId = @userId AND n.IsDeleted = 0 
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
