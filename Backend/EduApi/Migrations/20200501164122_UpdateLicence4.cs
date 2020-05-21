using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateLicence4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE Cb_License SET 
MaximumCourse = 0, OneYearSale = 12
WHERE SystemIdentificator = 'ENTERPRISE'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
