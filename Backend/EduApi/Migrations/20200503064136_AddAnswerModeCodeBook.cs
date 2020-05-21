using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddAnswerModeCodeBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerMode",
                table: "Edu_TestQuestion");

            migrationBuilder.AddColumn<Guid>(
                name: "AnswerModeId",
                table: "Edu_TestQuestion",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cb_AnswerMode",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_AnswerMode", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestQuestion_AnswerModeId",
                table: "Edu_TestQuestion",
                column: "AnswerModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_TestQuestion_Cb_AnswerMode_AnswerModeId",
                table: "Edu_TestQuestion",
                column: "AnswerModeId",
                principalTable: "Cb_AnswerMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_TestQuestion_Cb_AnswerMode_AnswerModeId",
                table: "Edu_TestQuestion");

            migrationBuilder.DropTable(
                name: "Cb_AnswerMode");

            migrationBuilder.DropIndex(
                name: "IX_Edu_TestQuestion_AnswerModeId",
                table: "Edu_TestQuestion");

            migrationBuilder.DropColumn(
                name: "AnswerModeId",
                table: "Edu_TestQuestion");

            migrationBuilder.AddColumn<string>(
                name: "AnswerMode",
                table: "Edu_TestQuestion",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
