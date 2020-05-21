using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class InsertDefaultEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] column = new string[]
            {
                "Id","IsDeleted","IsSystemObject","IsChanged","SystemIdentificator","Subject","EmailBodyHtml","EmailBodyPlainText","IsHtml","From"
            };
            object[] value = new object[]
            {
                Guid.NewGuid(),false,true,true,"REGISTRATION_USER_cs-CZ","Potvrzení registrace","Děkujeme Vám za registraci","Děkujeme Vám za registraci",true,"info@myedu.com"
            };
            migrationBuilder.InsertData("Cb_Email", column, value);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
