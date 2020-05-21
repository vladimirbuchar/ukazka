using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateBranchProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create PROCEDURE UpdateBranch
@BranchId uniqueidentifier ,
@IsMainBranch bit 
,@ContactInformationEmail nvarchar(max) 
,@ContactInformationPhoneNumber nvarchar(max) 
,@ContactInformationWWW nvarchar(max) 
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max) 
,@AddressCountryId uniqueidentifier 
,@AddressRegion nvarchar(max) 
,@AddressCity nvarchar(max) 
,@AddressStreet nvarchar(max) 
,@AddressHouseNumber nvarchar(max) 
,@AddressZipCode nvarchar(max) 


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

DECLARE @ContactInformationId uniqueidentifier 
SET @ContactInformationId  = (SELECT b.ContactInformationId FROM Edu_Branch b WHERE b.Id = @BranchId)
DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = (SELECT b.BasicInformationId FROM Edu_Branch b WHERE b.Id = @BranchId)
DECLARE @AddressId uniqueidentifier 
SET @AddressId  = (SELECT b.AddressId FROM Edu_Branch b WHERE b.Id = @BranchId)
DECLARE @OrganizationId uniqueidentifier 
SET @OrganizationId  = (SELECT b.OrganizationId FROM Edu_Branch b WHERE b.Id = @BranchId)

if @IsMainBranch =1
Begin
	UPDATE Edu_Branch SET IsMainBranch = 0 WHERE OrganizationId = @OrganizationId
End
UPDATE Shared_ContactInformation SET PhoneNumber =@ContactInformationPhoneNumber, 
WWW = @ContactInformationWWW, Email =@ContactInformationEmail WHERE Id = @ContactInformationId

UPDATE Shared_BasicInformation SET Name =@BasicInformationName, Description =@BasicInformationDescription
WHERE Id= @BasicInformationId

UPDATE Shared_Address  SET 
CountryId = @AddressCountryId, Region =@AddressRegion,City =@AddressCity,Street =@AddressStreet,HouseNumber =@AddressHouseNumber,
ZipCode = @AddressZipCode WHERE Id =@AddressId 

UPDATE Edu_Branch SET IsMainBranch =@IsMainBranch  WHERE Id = @BranchId
COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
