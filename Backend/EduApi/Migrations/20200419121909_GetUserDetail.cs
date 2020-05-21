using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class GetUserDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTerm_Link_CourseStudent_CourseStudentId",
                table: "Edu_CourseTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_Edu_User_Link_CourseStudent_CourseStudentId",
                table: "Edu_User");

            migrationBuilder.DropIndex(
                name: "IX_Edu_User_CourseStudentId",
                table: "Edu_User");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTerm_CourseStudentId",
                table: "Edu_CourseTerm");

            migrationBuilder.DropColumn(
                name: "CourseTermId",
                table: "Link_CourseLector");

            migrationBuilder.DropColumn(
                name: "UserInOrganizationId",
                table: "Link_CourseLector");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Link_CourseCategory");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Link_CourseCategory");

            migrationBuilder.DropColumn(
                name: "CourseStudentId",
                table: "Edu_User");

            migrationBuilder.DropColumn(
                name: "CourseStudentId",
                table: "Edu_CourseTerm");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Link_CourseStudent",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseTermId",
                table: "Link_CourseStudent",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseStudent_CourseTermId",
                table: "Link_CourseStudent",
                column: "CourseTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseStudent_UserId",
                table: "Link_CourseStudent",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_CourseStudent_Edu_CourseTerm_CourseTermId",
                table: "Link_CourseStudent",
                column: "CourseTermId",
                principalTable: "Edu_CourseTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_CourseStudent_Edu_User_UserId",
                table: "Link_CourseStudent",
                column: "UserId",
                principalTable: "Edu_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_CourseStudent_Edu_CourseTerm_CourseTermId",
                table: "Link_CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_CourseStudent_Edu_User_UserId",
                table: "Link_CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_Link_CourseStudent_CourseTermId",
                table: "Link_CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_Link_CourseStudent_UserId",
                table: "Link_CourseStudent");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Link_CourseStudent",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseTermId",
                table: "Link_CourseStudent",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseTermId",
                table: "Link_CourseLector",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserInOrganizationId",
                table: "Link_CourseLector",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Link_CourseCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Link_CourseCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CourseStudentId",
                table: "Edu_User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseStudentId",
                table: "Edu_CourseTerm",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_User_CourseStudentId",
                table: "Edu_User",
                column: "CourseStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_CourseStudentId",
                table: "Edu_CourseTerm",
                column: "CourseStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTerm_Link_CourseStudent_CourseStudentId",
                table: "Edu_CourseTerm",
                column: "CourseStudentId",
                principalTable: "Link_CourseStudent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_User_Link_CourseStudent_CourseStudentId",
                table: "Edu_User",
                column: "CourseStudentId",
                principalTable: "Link_CourseStudent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
