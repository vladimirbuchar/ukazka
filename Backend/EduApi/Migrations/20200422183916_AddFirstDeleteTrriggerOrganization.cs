using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class AddFirstDeleteTrriggerOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTrigger("SetIsDeleted_Edu_Organization");
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "Shared_BasicInformation", "BasicInformationId" },
                { "Shared_ContactInformation", "ContactInformationId" }
            };
            migrationBuilder.AddTriggerIsDeleted("Edu_Organization", param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
