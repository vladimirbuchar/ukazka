using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddPriorityToEduOrganizationRoleX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("AddCourseLector", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Link_CourseLector",
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>() { { "@CourseTermId", "uniqueidentifier" }, { "@UserInOrganizationId", "uniqueidentifier" } }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
