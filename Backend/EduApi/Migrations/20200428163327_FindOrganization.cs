using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class FindOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSqlFunctionAsTable("FindOrganization", @"
                            SELECT o.Id, obi.Name AS OrganizationName, obi.Description AS OrganizationDescription,
                            ba.City, ba.Street, ba.HouseNumber,ba.Region,Cbc.Name AS Country
                            FROM Edu_Organization AS o
                            JOIN Shared_BasicInformation AS obi ON o.BasicInformationId = obi.Id AND obi.IsDeleted = 0
                            LEFT JOIN Edu_Branch AS b ON  o.Id  = b.OrganizationId and b.IsDeleted = 0
                            LEFT JOIN Shared_Address AS ba ON b.AddressId = ba.Id  and ba.IsDeleted = 0
                            LEFT JOIN Cb_Country as cbc ON ba.CountryId = cbc.Id and cbc.IsDeleted = 0
                            WHERE o.IsDeleted = 0 
							AND (obi.Name COLLATE Latin1_general_CI_AI Like '%'+@findText+'%' COLLATE Latin1_general_CI_AI
							OR obi.Description COLLATE Latin1_general_CI_AI Like '%'+@findText+'%' COLLATE Latin1_general_CI_AI)",
            new System.Collections.Generic.Dictionary<string, string>() { { "@findText", "varchar(max)" } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
