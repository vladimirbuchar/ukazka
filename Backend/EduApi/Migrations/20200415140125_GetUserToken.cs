using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetUserToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string query = @"SELECT Id,UserToken FROM Edu_User AS u
                             WHERE u.UserEmail = @userName AND u.UserPassword = @password AND u.IsActive = 1 
                                  AND  u.IsDeleted = 0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@userName", "varchar(max)" },
                { "@password", "varchar(max)" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetUserToken", query, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSqlFunction("GetUserToken");
        }
    }
}
