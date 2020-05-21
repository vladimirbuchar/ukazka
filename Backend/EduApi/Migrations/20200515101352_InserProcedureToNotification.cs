using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class InserProcedureToNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("AddNotification", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Edu_Notification",
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>()
                {
                    {"@NotificationTypeId","uniqueidentifier" },
                    {"@ObjectId", "uniqueidentifier"},
                    {"@UserId","uniqueidentifier" },
                    {"@IsNew","bit" }
                }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
