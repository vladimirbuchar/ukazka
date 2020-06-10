using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCourseLessonItemTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cb_CourseLessonItemTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_CourseLessonItemTemplate", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cb_CourseLessonItemTemplate");
        }
    }
}
