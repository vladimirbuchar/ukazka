using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class InsertDataToAnswerMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<string> answerMode = new List<string>
            {
                "SELECT_ONE",
                "SELECT_MANY",
                "TEXT"
            };
            foreach (string item in answerMode)
            {
                migrationBuilder.InsertData("Cb_AnswerMode"
                    , new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Name", "Value", "IsDefault", "Priority" }
                    , new object[] { Guid.NewGuid(), false, true, true, null, item, item, false, 0 });
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
