using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class CheckExistEmailAddId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string query = "SELECT Id,UserEmail FROM Edu_User WHERE UserEmail =@userEmail AND IsDeleted =0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@userEmail", "varchar(max)" }
            };
            migrationBuilder.AlterSqlFunctionAsTable("CheckUserEmailExist", query, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string query = "SELECT UserEmail FROM Edu_User WHERE UserEmail =@userEmail AND IsDeleted =0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@userEmail", "varchar(max)" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("CheckUserEmailExist", query, param);
        }
    }
}
