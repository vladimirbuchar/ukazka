using Microsoft.EntityFrameworkCore.Migrations;
using Core.Extension;


namespace EduApi.Migrations
{
    public partial class SaveFileRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("AddFileRepositoryItem", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Edu_FileRepository",
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>()
                {
                    { "@ObjectOwner","uniqueidentifier" },
                    {"@FileName","nvarchar(max)" },
                    {"@OriginalFileName","nvarchar(max)" }
                }

            });
        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
