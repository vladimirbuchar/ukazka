using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetBankOfQuestionDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSqlFunctionAsTable("GetBankOfQuestionDetail", @"SELECT boq.Id,sbi.Description,sbi.Name  FROM Edu_BankOfQuestion AS boq
JOIN Shared_BasicInformation AS sbi ON boq.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
WHERE boq.Id = @BankQuestionId AND boq.IsDeleted = 0", new System.Collections.Generic.Dictionary<string, string>()
            {
                {"@BankQuestionId","uniqueidentifier" }
            }
 );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
