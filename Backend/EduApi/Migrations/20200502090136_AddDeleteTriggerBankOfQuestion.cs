using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class AddDeleteTriggerBankOfQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddTriggerIsDeleted("Edu_BankOfQuestion");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
