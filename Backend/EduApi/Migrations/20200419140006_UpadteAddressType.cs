using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpadteAddressType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData("Cb_AddressType", "SystemIdentificator", "MailingAddress", "SystemIdentificator", "MAILING_ADDRESS");
            migrationBuilder.UpdateData("Cb_AddressType", "SystemIdentificator", "PernamentAddress", "SystemIdentificator", "PERNAMENT_ADDRESS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
