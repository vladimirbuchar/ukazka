using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetClassRoomDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string query = @"SELECT c.Id,c.Floor,c.MaxCapacity,bi.Name, bi.Description
                                FROM Edu_ClassRoom as c
                                JOIN Shared_BasicInformation AS bi ON c.BasicInformationId = bi.Id
                                WHERE c.Id = @classRoomId AND c.IsDeleted = 0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@classRoomId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetClassRoomDetail", query, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
