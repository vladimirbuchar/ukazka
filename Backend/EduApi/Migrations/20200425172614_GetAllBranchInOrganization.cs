using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetAllBranchInOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT b.Id, b.IsMainBranch, a.CountryId, Region, City, Street, HouseNumber, ZipCode, Name,
                            Description, Email, PhoneNumber, WWW    
                           FROM Edu_Branch as b
                           JOIN Shared_Address AS a on a.Id = b.AddressId
                           JOIN Shared_BasicInformation AS bi on bi.Id = b.BasicInformationId
                           JOIN Shared_ContactInformation as c on c.Id = b.ContactInformationId
                            WHERE b.OrganizationId =@organizationId AND b.IsDeleted = 0 AND a.IsDeleted = 0 
                            AND bi.IsDeleted = 0 AND c.IsDeleted = 0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@organizationId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetAllBranchInOrganization", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
