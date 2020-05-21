using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class AddDelateTriggerToAllSystemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<string> tables = new List<string>()
            {
               "System_DataMigration","System_ObjectHistory"
            };
            foreach (string item in tables)
            {
                migrationBuilder.AddTriggerIsDeleted(item);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
