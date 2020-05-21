using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddBankOfQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_TestQuestion_Edu_CourseTest_CourseTestId",
                table: "Edu_TestQuestion");

            migrationBuilder.DropIndex(
                name: "IX_Edu_TestQuestion_CourseTestId",
                table: "Edu_TestQuestion");

            migrationBuilder.DropColumn(
                name: "CourseTestId",
                table: "Edu_TestQuestion");

            migrationBuilder.AddColumn<Guid>(
                name: "BankOfQuestionId",
                table: "Edu_TestQuestion",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Edu_BankOfQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_BankOfQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_BankOfQuestion_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_BankOfQuestion_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestQuestion_BankOfQuestionId",
                table: "Edu_TestQuestion",
                column: "BankOfQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_BankOfQuestion_BasicInformationId",
                table: "Edu_BankOfQuestion",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_BankOfQuestion_OrganizationId",
                table: "Edu_BankOfQuestion",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_TestQuestion_Edu_BankOfQuestion_BankOfQuestionId",
                table: "Edu_TestQuestion",
                column: "BankOfQuestionId",
                principalTable: "Edu_BankOfQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_TestQuestion_Edu_BankOfQuestion_BankOfQuestionId",
                table: "Edu_TestQuestion");

            migrationBuilder.DropTable(
                name: "Edu_BankOfQuestion");

            migrationBuilder.DropIndex(
                name: "IX_Edu_TestQuestion_BankOfQuestionId",
                table: "Edu_TestQuestion");

            migrationBuilder.DropColumn(
                name: "BankOfQuestionId",
                table: "Edu_TestQuestion");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseTestId",
                table: "Edu_TestQuestion",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestQuestion_CourseTestId",
                table: "Edu_TestQuestion",
                column: "CourseTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_TestQuestion_Edu_CourseTest_CourseTestId",
                table: "Edu_TestQuestion",
                column: "CourseTestId",
                principalTable: "Edu_CourseTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
