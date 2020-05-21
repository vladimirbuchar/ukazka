using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class DeactivateUserAfterDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTrigger("SetIsDeleted_Edu_User");
            string query = @"UPDATE u SET u.IsActive = 0
                              FROM Edu_User AS u
                              INNER JOIN deleted AS d
                              ON u.Id = d.Id AND u.IsSystemObject = 0 ";
            migrationBuilder.AddTriggerIsDeleted("Edu_User", query);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
