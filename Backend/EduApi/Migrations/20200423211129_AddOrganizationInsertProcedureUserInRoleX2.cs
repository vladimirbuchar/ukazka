﻿using Core.DataTypes;
using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

namespace EduApi.Migrations
{
    public partial class AddOrganizationInsertProcedureUserInRoleX2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSqlProcedure("CreateOrganization");
            CustomInsert customInsert = new CustomInsert
            {
                TableName = "Link_UserInOrganization"
            };
            customInsert.Columns.Add(new QueryColumn() { ColumnName = "OrganizationId", ColumnValue = "@Edu_Organization_id" });
            customInsert.Columns.Add(new QueryColumn() { ColumnName = "OrganizationRoleId", ColumnValue = "@OrganizationRoleId" });
            customInsert.Columns.Add(new QueryColumn() { ColumnName = "UserId", ColumnValue = "@UserId" });
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DECLARE @OrganizationRoleId uniqueidentifier");
            sb.AppendLine("SET @OrganizationRoleId = (SELECT Id FROM Edu_OrganizationRole WHERE SystemIdentificator = @OrganizationRoleIdentificator AND IsDeleted = 0) ");
            customInsert.BeforeQuery.Add(sb.ToString());
            CustomUpdate customUpdate = new CustomUpdate()
            {
                TableName = "Edu_Organization"
            };
            customUpdate.Columns.Add(new QueryColumn() { ColumnName = "LicenseId", ColumnValue = "@LicenseId" });
            customUpdate.WhereColumns.Add(new QueryColumn() { ColumnName = "Id", ColumnValue = "@Edu_Organization_id" });
            StringBuilder sbUpdate = new StringBuilder();
            sbUpdate.AppendLine("DECLARE @LicenseId uniqueidentifier");
            sbUpdate.AppendLine("SET @LicenseId = (SELECT Id FROM Cb_License WHERE SystemIdentificator = @LicenseIdentificator AND IsDeleted = 0) ");
            customUpdate.BeforeQuery.Add(sbUpdate.ToString());

            migrationBuilder.CreateInsertProcedure("CreateOrganization", new InsertProcedureTableConfig()
            {
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>() { { "@CanSendCourseInquiry", "bit" } },
                SaveBasicInformation = true,
                TableName = "Edu_Organization",
                SaveContactInformation = true,
                CustomProcedureParametrs = new System.Collections.Generic.Dictionary<string, string>() { { "@UserId", "uniqueidentifier" }, { "@OrganizationRoleIdentificator", "nvarchar(max)" }, { "@LicenseIdentificator", "nvarchar(max)" } },
                CustomInsert = new System.Collections.Generic.List<CustomInsert>() { customInsert },
                CustomUpdate = new System.Collections.Generic.List<CustomUpdate>() { customUpdate }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
