using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetAllCourseInOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT c.Id, bi.Name FROM Edu_Course AS c
                           JOIN Shared_BasicInformation AS bi ON c.BasicInformationId = bi.Id
                            WHERE c.IsDeleted = 0 AND bi.IsDeleted = 0 AND c.OrganizationId = @organizationId";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@organizationId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetAllCourseInOrganization", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
