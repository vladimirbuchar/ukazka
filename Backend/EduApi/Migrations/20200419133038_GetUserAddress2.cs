using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetUserAddress2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSqlFunction("GetUserAddress");
            string query = @"SELECT a.Id,a.CountryId,a.Region,a.City,a.Street, a.HouseNumber,a.ZipCode,a.AddressTypeId, at.SystemIdentificator AS AddressTypeIdentificator
                            FROM  Shared_Address AS a
                            JOIN Cb_AddressType AS at ON at.Id =  a.AddressTypeId
                            WHERE a.PersonId = @personOid AND a.IsDeleted = 0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@personOid", "uniqueidentifier" },
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetUserAddress", query, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSqlFunction("GetUserAddress");
            string query = @"SELECT a.Id,a.CountryId,a.Region,a.City,a.Street, a.HouseNumber,a.ZipCode,a.AddressTypeId
                            FROM  Shared_Address AS a
                            WHERE a.PersonId = @personOid AND a.IsDeleted = 0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@personOid", "uniqueidentifier" },
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetUserAddress", query, param);
        }
    }
}
