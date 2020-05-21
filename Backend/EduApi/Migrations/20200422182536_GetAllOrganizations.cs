using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllOrganizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT o.Id,bi.Name,bi.Description,l.Priority
                            FROM Edu_Organization AS o
                            JOIN Shared_BasicInformation AS bi ON o.BasicInformationId = bi.Id
                            JOIN Cb_License AS l ON o.LicenseId = l.Id
                            WHERE o.IsDeleted = 0 AND l.IsDeleted = 0";
            migrationBuilder.CreateSqlFunctionAsTable("GetAllOrganizations", sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSqlFunction("GetAllOrganizations");
        }
    }
}
