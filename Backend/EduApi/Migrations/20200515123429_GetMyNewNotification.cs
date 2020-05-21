using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetMyNewNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string query = "SELECT Id,NotificationTypeId,ObjectId FROM Edu_Notification WHERE UserId =@userId AND IsDeleted =0 AND IsNew = 1";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@userId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetMyNewNotification", query, param);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
