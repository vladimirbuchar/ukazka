using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].[GetOrganizationAddress](@organizationOid uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT a.Id,a.CountryId,a.Region,a.City,a.Street, a.HouseNumber,a.ZipCode,a.AddressTypeId, at.SystemIdentificator AS AddressTypeIdentificator
                            FROM  Shared_Address AS a
                            JOIN Cb_AddressType AS at ON at.Id =  a.AddressTypeId
                            WHERE a.OrganizationId = @organizationOid AND a.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
