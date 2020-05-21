using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddAddressToOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Shared_Address",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shared_Address_OrganizationId",
                table: "Shared_Address",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shared_Address_Edu_Organization_OrganizationId",
                table: "Shared_Address",
                column: "OrganizationId",
                principalTable: "Edu_Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shared_Address_Edu_Organization_OrganizationId",
                table: "Shared_Address");

            migrationBuilder.DropIndex(
                name: "IX_Shared_Address_OrganizationId",
                table: "Shared_Address");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Shared_Address");
        }
    }
}
