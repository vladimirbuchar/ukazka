using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class DeleteAllFilesInFileRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE  PROCEDURE DeleteAllFilesInFileRepository
@ObjectOwner uniqueidentifier 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DELETE FROM Edu_FileRepository WHERE ObjectOwner = @ObjectOwner
COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
