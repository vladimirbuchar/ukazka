using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddFileRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edu_FileRepository",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    ObjectOwner = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    OriginalFileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_FileRepository", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_FileRepository");
        }
    }
}
