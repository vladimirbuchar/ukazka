using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddDataToNotificationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] column = new string[]
            {
                "Id","IsDeleted","IsSystemObject","IsChanged","SystemIdentificator","Name","Value","IsDefault","Priority"
            };
            object[] values = new object[]
            {
                Guid.NewGuid(),false,true,true,"INVITE_TO_ORGANIZATION","INVITE_TO_ORGANIZATION","INVITE_TO_ORGANIZATION",false,0
            };
            migrationBuilder.InsertData("Cb_NotificationType", column, values);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
