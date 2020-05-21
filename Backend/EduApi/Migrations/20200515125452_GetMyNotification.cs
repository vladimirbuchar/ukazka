using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetMyNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string query = @"SELECT n.Id,nt.SystemIdentificator AS NotificationIdentificator ,n.ObjectId FROM Edu_Notification  AS n
JOIN Cb_NotificationType AS nt ON n.NotificationTypeId = nt.Id
WHERE n.UserId = @userId AND n.IsDeleted = 0 AND n.IsNew = 1";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@userId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetMyNotification", query, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
