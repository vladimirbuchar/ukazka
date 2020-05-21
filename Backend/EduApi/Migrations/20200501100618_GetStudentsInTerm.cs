using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetStudentsInTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT cs.Id, p.FirstName, p.LastName,p.SecondName, cs.UserId AS StudentId
                            FROM Link_CourseStudent AS cs
                            JOIN Edu_User AS u ON cs.UserId = u.Id
                            JOIN Edu_Person AS p ON p.Id = u.PersonId
                            WHERE cs.CourseTermId = @courseTermId AND cs.IsDeleted = 0 AND u.IsDeleted = 0 
                            AND p.IsDeleted = 0";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@courseTermId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetStudentsInTerm", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
