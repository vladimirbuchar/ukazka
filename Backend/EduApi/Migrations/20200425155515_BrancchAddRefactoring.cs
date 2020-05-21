using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class BrancchAddRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Branch_Shared_ContactInformation_ContactInformationsId",
                table: "Edu_Branch");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Branch_ContactInformationsId",
                table: "Edu_Branch");

            migrationBuilder.DropColumn(
                name: "ContactInformationsId",
                table: "Edu_Branch");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactInformationId",
                table: "Edu_Branch",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Branch_ContactInformationId",
                table: "Edu_Branch",
                column: "ContactInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Branch_Shared_ContactInformation_ContactInformationId",
                table: "Edu_Branch",
                column: "ContactInformationId",
                principalTable: "Shared_ContactInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Branch_Shared_ContactInformation_ContactInformationId",
                table: "Edu_Branch");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Branch_ContactInformationId",
                table: "Edu_Branch");

            migrationBuilder.DropColumn(
                name: "ContactInformationId",
                table: "Edu_Branch");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactInformationsId",
                table: "Edu_Branch",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Branch_ContactInformationsId",
                table: "Edu_Branch",
                column: "ContactInformationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Branch_Shared_ContactInformation_ContactInformationsId",
                table: "Edu_Branch",
                column: "ContactInformationsId",
                principalTable: "Shared_ContactInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
