using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetLicenseByOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT l.Id, l.Name,l.Value,
                            l.IsDefault,l.MaximumStudents,l.MaximumBranch,l.MaximumLectors,l.MaximumCourse,
                            l.MounthPrice,l.OneYearSale,l.OneYearPrice,l.Support,l.SendCourseInquiry,
                            l.CreatePrivateCourse,l.Priority
                           FROM Cb_License AS l
                           JOIN Edu_Organization AS o ON l.Id = o.LicenseId
                           WHERE o.IsDeleted = 0 AND l.IsDeleted = 0 AND o.Id = @organizationId";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@organizationId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetLicenseByOrganization", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
