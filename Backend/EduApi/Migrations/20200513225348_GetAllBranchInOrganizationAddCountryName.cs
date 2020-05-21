using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllBranchInOrganizationAddCountryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllBranchInOrganization](@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT b.Id, b.IsMainBranch, a.CountryId, Region, City, Street, HouseNumber, ZipCode, bi.Name,cbc.Name AS CountryName,
                            bi.Description, Email, PhoneNumber, WWW    
                           FROM Edu_Branch as b
                           JOIN Shared_Address AS a on a.Id = b.AddressId
                           JOIN Shared_BasicInformation AS bi on bi.Id = b.BasicInformationId
                           JOIN Shared_ContactInformation as c on c.Id = b.ContactInformationId
						   JOIN Cb_Country as cbc ON a.CountryId = cbc.Id
                            WHERE b.OrganizationId =@organizationId AND b.IsDeleted = 0 AND a.IsDeleted = 0 
                            AND bi.IsDeleted = 0 AND c.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
