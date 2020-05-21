using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCourseLector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_CourseStudent_Edu_User_UserId",
                table: "Link_CourseStudent");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_CourseStudent_Link_UserInOrganization_UserId",
                table: "Link_CourseStudent",
                column: "UserId",
                principalTable: "Link_UserInOrganization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_CourseStudent_Link_UserInOrganization_UserId",
                table: "Link_CourseStudent");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_CourseStudent_Edu_User_UserId",
                table: "Link_CourseStudent",
                column: "UserId",
                principalTable: "Edu_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
