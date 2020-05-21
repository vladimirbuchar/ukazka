using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllSliderItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT s.Id, s.Image, bi.Name,bi.Description,s.Priority
                           FROM Edu_Slider AS s
                           JOIN Shared_BasicInformation AS bi ON s.BasicInformationId = bi.Id
                           WHERE s.IsDeleted = 0 ";
            migrationBuilder.CreateSqlFunctionAsTable("GetAllSliderItems", sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSqlFunction("GetAllSliderItems");
        }
    }
}
