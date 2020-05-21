using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetAllCourseTermLector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"SELECT l.Id, p.FirstName, p.LastName,p.SecondName FROM Link_CourseLector as l
                            join Link_UserInOrganization as uio ON l.UserInOrganizationId= uio.Id
                            join Edu_User as u ON uio.UserId = u.Id
                            join Edu_Person as p ON u.PersonId = p.Id
                           WHERE l.CourseTermId = @courseTermId AND l.IsDeleted = 0 AND uio.IsDeleted =0 
                            AND u.IsDeleted = 0 AND p.IsDeleted = 0	";
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@courseTermId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetAllCourseTermLector", sql, param);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
