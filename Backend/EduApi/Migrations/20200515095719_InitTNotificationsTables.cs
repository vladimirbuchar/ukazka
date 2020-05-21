using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class InitTNotificationsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddTriggerIsDeleted("Cb_NotificationType");
            migrationBuilder.AddTriggerIsDeleted("Edu_Notifications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
