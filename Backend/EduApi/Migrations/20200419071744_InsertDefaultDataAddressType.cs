using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class InsertDefaultDataAddressType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] columns = new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "IsDefault", "Priority" };
            object[] PernamentAddress = new object[] { Guid.NewGuid(), false, true, true, "PernamentAddress", false, 0 };
            object[] MailingAddress = new object[] { Guid.NewGuid(), false, true, true, "MailingAddress", false, 0 };
            migrationBuilder.InsertData("Cb_AddressType", columns, PernamentAddress);
            migrationBuilder.InsertData("Cb_AddressType", columns, MailingAddress);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
