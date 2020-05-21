using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddStudentToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("AddStudentToCourse", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Link_CourseStudent",
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>() { { "@UserId", "uniqueidentifier" }, { "@CourseTermId", "uniqueidentifier" } }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
