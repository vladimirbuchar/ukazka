using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class InsertCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Cb_Country", new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Name", "Value", "IsDefault", "Priority" },
              new object[] {
                Guid.NewGuid() ,false,true,true,"CZ","Česká republika","CZ",true,1
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
