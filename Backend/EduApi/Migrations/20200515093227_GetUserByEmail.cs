using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetUserByEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string query = @"SELECT u.Id, u.UserEmail, p.FirstName, p.SecondName, p.LastName, p.Id AS PersonId
                             FROM Edu_User AS u
                             JOIN Edu_Person AS p ON u.PersonId = p.Id
                             WHERE u.UserEmail = @userEmail AND u.IsDeleted = 0 AND p.IsDeleted = 0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@userEmail", "varchar(max)" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetUserDetailByEmail", query, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
