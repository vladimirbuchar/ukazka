using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AlterGetMyNewNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetMyNewNotification](@userId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT n.Id,nt.SystemIdentificator AS NotificationIdentificator ,n.ObjectId FROM Edu_Notification  AS n
JOIN Cb_NotificationType AS nt ON n.NotificationTypeId = nt.Id
WHERE n.UserId =@userId AND n.IsDeleted =0 AND n.IsNew = 1
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
