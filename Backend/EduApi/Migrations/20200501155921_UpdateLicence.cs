using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateLicence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaximumLectors",
                table: "Cb_License");

            migrationBuilder.DropColumn(
                name: "MaximumStudents",
                table: "Cb_License");

            migrationBuilder.DropColumn(
                name: "Support",
                table: "Cb_License");

            migrationBuilder.AddColumn<int>(
                name: "MaximumUser",
                table: "Cb_License",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaximumUser",
                table: "Cb_License");

            migrationBuilder.AddColumn<int>(
                name: "MaximumLectors",
                table: "Cb_License",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaximumStudents",
                table: "Cb_License",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Support",
                table: "Cb_License",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
