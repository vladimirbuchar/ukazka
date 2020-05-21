using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetOrganizationByBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT  o.Id
                           FROM Edu_Organization AS o
                           JOIN Edu_Branch AS b ON b.OrganizationId = o.Id
                           WHERE b.IsDeleted = 0 AND o.IsDeleted = 0 AND b.Id = @branchId";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@branchId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetOrganizationByBranch", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
