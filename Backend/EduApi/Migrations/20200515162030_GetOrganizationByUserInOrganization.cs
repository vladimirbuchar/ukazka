using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetOrganizationByUserInOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT o.Id,o.IsDeleted,o.IsSystemObject,o.IsChanged,o.SystemIdentificator,o.BasicInformationId,
                                  o.LicenseId,o.CanSendCourseInquiry  
                            FROM Link_UserInOrganization AS uio 
                            JOIN Edu_Organization AS o ON o.Id = uio.OrganizationId
                            WHERE uio.Id = @userInOrganizationId AND uio.IsDeleted = 0 AND o.IsDeleted = 0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@userInOrganizationId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetOrganizationByUserInOrganization", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
