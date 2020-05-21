using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class AddTrigerrDeletePersonInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTrigger("SetIsDeleted_Edu_User");
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "Edu_Person", "PersonId" }
            };
            migrationBuilder.AddTriggerIsDeleted("Edu_User", param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
