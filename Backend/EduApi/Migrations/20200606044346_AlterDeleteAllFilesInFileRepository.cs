using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AlterDeleteAllFilesInFileRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[DeleteAllFilesInFileRepository]
@ObjectOwner uniqueidentifier 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Id uniqueidentifier

DECLARE MY_CURSOR CURSOR 
  LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT DISTINCT Id 
FROM Edu_FileRepository WHERE ObjectOwner = @ObjectOwner

OPEN MY_CURSOR
FETCH NEXT FROM MY_CURSOR INTO @Id
WHILE @@FETCH_STATUS = 0
BEGIN 
	DELETE FROM Edu_FileRepository WHERE Id = @Id
    FETCH NEXT FROM MY_CURSOR INTO @Id
END
CLOSE MY_CURSOR
DEALLOCATE MY_CURSOR

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
