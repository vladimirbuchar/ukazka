using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class AddDeleteProcedureAnswerMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateDeleteProcedure("Cb_AnswerMode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
