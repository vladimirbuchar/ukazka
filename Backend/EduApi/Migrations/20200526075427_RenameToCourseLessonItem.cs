using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class RenameToCourseLessonItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_CourseItem");

            migrationBuilder.CreateTable(
                name: "Edu_CourseLessonItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Html = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    CourseLessonItemTemplateId = table.Column<Guid>(nullable: true),
                    CourseLessonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseLessonItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseLessonItem_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseLessonItem_Edu_CourseLesson_CourseLessonId",
                        column: x => x.CourseLessonId,
                        principalTable: "Edu_CourseLesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseLessonItem_Cb_CourseLessonItemTemplate_CourseLessonItemTemplateId",
                        column: x => x.CourseLessonItemTemplateId,
                        principalTable: "Cb_CourseLessonItemTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLessonItem_BasicInformationId",
                table: "Edu_CourseLessonItem",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLessonItem_CourseLessonId",
                table: "Edu_CourseLessonItem",
                column: "CourseLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLessonItem_CourseLessonItemTemplateId",
                table: "Edu_CourseLessonItem",
                column: "CourseLessonItemTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLessonItem_SystemIdentificator",
                table: "Edu_CourseLessonItem",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_CourseLessonItem");

            migrationBuilder.CreateTable(
                name: "Edu_CourseItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasicInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CourseLessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CourseLessonItemTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChanged = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseItem_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseItem_Edu_CourseLesson_CourseLessonId",
                        column: x => x.CourseLessonId,
                        principalTable: "Edu_CourseLesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseItem_Cb_CourseLessonItemTemplate_CourseLessonItemTemplateId",
                        column: x => x.CourseLessonItemTemplateId,
                        principalTable: "Cb_CourseLessonItemTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseItem_BasicInformationId",
                table: "Edu_CourseItem",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseItem_CourseLessonId",
                table: "Edu_CourseItem",
                column: "CourseLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseItem_CourseLessonItemTemplateId",
                table: "Edu_CourseItem",
                column: "CourseLessonItemTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseItem_SystemIdentificator",
                table: "Edu_CourseItem",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");
        }
    }
}
