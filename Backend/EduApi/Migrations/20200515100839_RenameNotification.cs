using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class RenameNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_Notifications");

            migrationBuilder.CreateTable(
                name: "Edu_Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    NotificationTypeId = table.Column<Guid>(nullable: true),
                    ObjectId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Notification_Cb_NotificationType_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "Cb_NotificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Notification_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Notification_Edu_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Notification_NotificationTypeId",
                table: "Edu_Notification",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Notification_OrganizationId",
                table: "Edu_Notification",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Notification_UserId",
                table: "Edu_Notification",
                column: "UserId");
            migrationBuilder.AddTriggerIsDeleted("Edu_Notification");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_Notification");

            migrationBuilder.CreateTable(
                name: "Edu_Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    NotificationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Notifications_Cb_NotificationType_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "Cb_NotificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Notifications_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Notifications_Edu_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Notifications_NotificationTypeId",
                table: "Edu_Notifications",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Notifications_OrganizationId",
                table: "Edu_Notifications",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Notifications_UserId",
                table: "Edu_Notifications",
                column: "UserId");
        }
    }
}
