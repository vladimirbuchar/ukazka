using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetOrganizationDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT o.Id,o.CanSendCourseInquiry,o.LicenseId, ci.Email,ci.PhoneNumber,ci.WWW,bi.Description,bi.Name
		                   FROM Edu_Organization AS o
		                   LEFT JOIN Shared_BasicInformation AS bi ON o.BasicInformationId = bi.Id AND bi.IsDeleted = 0 
		                   LEFT JOIN Shared_ContactInformation AS ci ON o.ContactInformationId = ci.Id AND ci.IsDeleted = 0
		                   WHERE o.Id = @organizationId AND o.IsDeleted= 0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@organizationId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetUserOrganizationRole", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSqlFunction("GetUserOrganizationRole");
        }
    }
}
