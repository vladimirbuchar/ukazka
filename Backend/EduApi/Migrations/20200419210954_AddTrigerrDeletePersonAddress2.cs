using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class AddTrigerrDeletePersonAddress2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTrigger("SetIsDeleted_Edu_Person");
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "Shared_Address", "PersonId" }
            };
            migrationBuilder.AddTriggerIsDeleted("Edu_Person", param, true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
