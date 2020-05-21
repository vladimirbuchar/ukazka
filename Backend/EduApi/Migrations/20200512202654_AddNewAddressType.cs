using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddNewAddressType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] columns = new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "IsDefault", "Priority" };
            object[] registeredOfficeAddress = new object[] { Guid.NewGuid(), false, true, true, "RegisteredOfficeAddress", false, 0 };
            object[] BillingAddress = new object[] { Guid.NewGuid(), false, true, true, "BillingAddress", false, 0 };
            migrationBuilder.InsertData("Cb_AddressType", columns, registeredOfficeAddress);
            migrationBuilder.InsertData("Cb_AddressType", columns, BillingAddress);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
