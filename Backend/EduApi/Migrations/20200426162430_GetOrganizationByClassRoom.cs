using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetOrganizationByClassRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT o.Id
                           FROM Edu_Organization as o
                           JOIN Edu_Branch as b ON b.OrganizationId = o.Id
                           JOIN Edu_ClassRoom as c ON c.BranchId = b.Id
                           WHERE b.IsDeleted = 0 AND c.IsDeleted = 0 AND o.IsDeleted = 0 AND c.Id = @classRoomId";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@classRoomId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetOrganizationByClassRoom", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
