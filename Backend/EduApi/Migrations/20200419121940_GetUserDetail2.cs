using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetUserDetail2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT u.Id, u.UserEmail, p.FirstName, p.SecondName, p.LastName, p.Id AS PersonId
                             FROM Edu_User AS u
                             JOIN Edu_Person AS p ON u.PersonId =p.Id
                             WHERE u.Id = @userId AND u.IsDeleted = 0 AND p.IsDeleted = 0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@userId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetUserDetail", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
