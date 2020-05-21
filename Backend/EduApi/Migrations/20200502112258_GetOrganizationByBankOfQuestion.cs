using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationByBankOfQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSqlFunctionAsTable("GetOrganizationByBankOfQuestion",
                @"SELECT o.Id
                   FROM Edu_Organization AS o
                   JOIN Edu_BankOfQuestion AS boq ON o.Id = boq.OrganizationId
                   WHERE boq.Id = @BankOfQuestionId AND boq.IsDeleted = 0 AND o.IsDeleted = 0 ",
                new System.Collections.Generic.Dictionary<string, string>()
                {
                    {"@BankOfQuestionId","uniqueidentifier" }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
