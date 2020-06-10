using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AlterGetCourseLessonItemDetailAddFileId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetCourseLessonItemDetail](@CourseLessonItemId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ci.Id, ci.Html, sbi.Name, sbi.Description, ci.CourseLessonItemTemplateId, clit.SystemIdentificator AS TemplateIdentificator,fr.FileName,fr.OriginalFileName, fr.Id AS FileId
				  FROM Edu_CourseLessonItem AS ci
				  LEFT JOIN Edu_FileRepository AS fr ON ci.Id = fr.ObjectOwner AND fr.IsDeleted = 0
                  JOIN Shared_BasicInformation as sbi ON ci.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
				  JOIN Cb_CourseLessonItemTemplate AS clit ON clit.Id = ci.CourseLessonItemTemplateId 
                  WHERE ci.Id = @CourseLessonItemId AND ci.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
