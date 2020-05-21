using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class BranchInOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Edu_Branch",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Branch_OrganizationId",
                table: "Edu_Branch",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Branch_Edu_Organization_OrganizationId",
                table: "Edu_Branch",
                column: "OrganizationId",
                principalTable: "Edu_Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Branch_Edu_Organization_OrganizationId",
                table: "Edu_Branch");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Branch_OrganizationId",
                table: "Edu_Branch");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Edu_Branch");
        }
    }
}
