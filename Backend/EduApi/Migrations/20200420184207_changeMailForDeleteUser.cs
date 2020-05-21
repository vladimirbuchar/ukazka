using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class changeMailForDeleteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTrigger("SetIsDeleted_Edu_User");
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "Edu_Person", "PersonId" }
            };
            string query = @"UPDATE u SET u.IsActive = 0,u.UserEmail = u.UserEmail+''+CONVERT(varchar(255), NEWID())
                              FROM Edu_User AS u
                              INNER JOIN deleted AS d
                              ON u.Id = d.Id AND u.IsSystemObject = 0 ";
            migrationBuilder.AddTriggerIsDeleted("Edu_User", param, query);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTrigger("SetIsDeleted_Edu_User");
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "Edu_Person", "PersonId" }
            };
            string query = @"UPDATE u SET u.IsActive = 0
                              FROM Edu_User AS u
                              INNER JOIN deleted AS d
                              ON u.Id = d.Id AND u.IsSystemObject = 0 ";
            migrationBuilder.AddTriggerIsDeleted("Edu_User", param, query);
        }
    }
}
