using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetOrganizationByCourseTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT o.Id
                           FROM Edu_Organization as o
                           JOIN Edu_Course as c ON o.Id = c.OrganizationId
                           JOIN Edu_CourseTerm as t ON c.Id = t.CourseId
                           WHERE t.Id = @courseTermId AND o.IsDeleted = 0 AND c.IsDeleted = 0 AND t.IsDeleted = 0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@courseTermId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetOrganizationByCourseTerm", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
