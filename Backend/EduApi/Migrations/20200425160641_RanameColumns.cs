using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class RanameColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Cb_AddressType",
                new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Name", "Value", "IsDefault", "Priority " },
                new object[] { Guid.NewGuid(), false, true, true, "BRANCH_ADDRESS", "BRANCH_ADDRESS", "BRANCH_ADDRESS", false, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
