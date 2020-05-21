using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateLicence3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE  Cb_License SET IsDefault = 1,Priority = 4,MaximumBranch = 1,MaximumCourse=25,CreatePrivateCourse=0,MounthPrice=0,OneYearSale=0,SendCourseInquiry =0,MaximumUser=25 WHERE SystemIdentificator= 'FREE'
UPDATE  Cb_License SET IsDefault = 0,Priority = 3,MaximumBranch = 10,MaximumCourse=250,CreatePrivateCourse=1,MounthPrice=299,OneYearSale=5,SendCourseInquiry =1,MaximumUser=250 WHERE SystemIdentificator= 'STANDARD'
UPDATE  Cb_License SET IsDefault = 0,Priority = 2,MaximumBranch = 100,MaximumCourse=250,CreatePrivateCourse=1,MounthPrice=599,OneYearSale=10,SendCourseInquiry =1,MaximumUser=1000 WHERE SystemIdentificator= 'PROFESIONAL'
UPDATE  Cb_License SET IsDefault = 0,Priority = 1,MaximumBranch = 0,MaximumCourse=250,CreatePrivateCourse=1,MounthPrice=899,OneYearSale=10,SendCourseInquiry =1,MaximumUser=0 WHERE SystemIdentificator= 'ENTERPRISE'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
