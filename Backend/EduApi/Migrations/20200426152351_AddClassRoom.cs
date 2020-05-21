using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddClassRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("CreateClassRoom", new Core.DataTypes.InsertProcedureTableConfig()
            {
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>() { { "@Floor", "int" },
                { "@BranchId", "uniqueidentifier" },{ "@MaxCapacity", "int" }},
                SaveBasicInformation = true,
                TableName = "Edu_ClassRoom",

            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
