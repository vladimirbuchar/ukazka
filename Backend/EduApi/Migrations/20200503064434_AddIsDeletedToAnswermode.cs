using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class AddIsDeletedToAnswermode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddTriggerIsDeleted("Cb_AnswerMode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
