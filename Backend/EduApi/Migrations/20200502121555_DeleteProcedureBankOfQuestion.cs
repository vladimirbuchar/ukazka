using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class DeleteProcedureBankOfQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateDeleteProcedure("Edu_BankOfQuestion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
