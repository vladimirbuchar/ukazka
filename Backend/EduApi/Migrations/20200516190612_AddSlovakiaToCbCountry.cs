using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddSlovakiaToCbCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] columns = new string[]
            {
                "Id","IsDeleted","IsSystemObject","IsChanged","SystemIdentificator","Name","Value","IsDefault","Priority"
            };
            object[] value = new object[]
            {
                Guid.NewGuid(),false,true,true,"SK","Slovenská republika","SK",false,2
            };
            migrationBuilder.InsertData("Cb_Country", columns, value);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
