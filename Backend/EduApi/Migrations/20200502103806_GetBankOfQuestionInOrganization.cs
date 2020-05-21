using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class GetBankOfQuestionInOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSqlFunctionAsTable("GetBankOfQuestionInOrganization", @"SELECT boq.Id,sbi.Description,sbi.Name  FROM Edu_BankOfQuestion AS boq
JOIN Shared_BasicInformation AS sbi ON boq.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
WHERE boq.OrganizationId = @OrganizationId AND boq.IsDeleted = 0",
new System.Collections.Generic.Dictionary<string, string>()
{
    { "OrganizationId","uniqueidentifier"}
});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
