using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetUserByAccessTokenAddIdAndEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSqlFunction("UserAccessTokenExist");
            string sql = @"SELECT Id,UserEmail, UserToken
                            FROM Edu_User AS u
                            WHERE u.UserToken = @accessToken AND u.IsActive = 1 AND u.IsDeleted = 0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@accessToken", "varchar(max)" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetUserByAccessToken", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
