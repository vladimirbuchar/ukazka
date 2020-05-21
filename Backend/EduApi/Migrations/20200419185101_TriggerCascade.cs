using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class TriggerCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTrigger("SetIsDeleted_Edu_User");
            migrationBuilder.AddTriggerIsDeleted("Edu_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
