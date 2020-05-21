using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetOrganizationByCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT o.Id
                                  FROM Edu_Organization AS o
                            JOIN Edu_Course AS c ON o.Id = c.OrganizationId
                            WHERE c.Id = @courseId AND c.IsDeleted = 0 AND o.IsDeleted = 0 ";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@courseId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetOrganizationByCourse", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
