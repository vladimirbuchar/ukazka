using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateLicence2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OneYearPrice",
                table: "Cb_License");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "OneYearPrice",
                table: "Cb_License",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
