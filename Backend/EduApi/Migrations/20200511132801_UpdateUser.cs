using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[UpdateUser] 
@FirstName nvarchar(max) ,
@SecondName nvarchar(max), 
@LastName nvarchar(max) 
,@UserId uniqueidentifier,

@paCountry uniqueidentifier,
@paRegion nvarchar(max) ,
@paCity nvarchar(max) ,
@paStreet nvarchar(max) ,
@paHouseNumber nvarchar(max) ,
@paZipCode nvarchar(max) ,

@maCountry uniqueidentifier,
@maRegion nvarchar(max) ,
@maCity nvarchar(max) ,
@maStreet nvarchar(max) ,
@maHouseNumber nvarchar(max) ,
@maZipCode nvarchar(max) 


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

DECLARE @PersonId uniqueidentifier 
SET @PersonId  = (SELECT PersonId FROM Edu_User WHERE Id =@UserId AND IsDeleted = 0)

DECLARE @PernamentAddressId uniqueidentifier;
SET @PernamentAddressId  = (SELECT a.Id FROM Shared_Address AS a  
JOIN Cb_AddressType AS  atype ON a.AddressTypeId = atype.Id AND atype.SystemIdentificator ='PERNAMENT_ADDRESS'
WHERe a.PersonId = @PersonId AND a.IsDeleted = 0
);

DECLARE @MailingAddressId uniqueidentifier;
SET @MailingAddressId  = (SELECT a.Id FROM Shared_Address AS a  
JOIN Cb_AddressType AS  atype ON a.AddressTypeId = atype.Id AND atype.SystemIdentificator ='MAILING_ADDRESS'
WHERe a.PersonId = @PersonId AND a.IsDeleted = 0
);

Update Edu_Person SET FirstName = @FirstName, SecondName =@SecondName, LastName = @LastName WHERE Id = @PersonId

if (@PernamentAddressId IS NULL)
INSERT Shared_Address (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,CountryId,Region,City,Street,HouseNumber,ZipCode,AddressTypeId,PersonId)
VALUES (NEWID(),0,0,1,null,@maCountry,@maRegion,@maCity,@maStreet,@maHouseNumber,@maZipCode,(SELECT Id FROM Cb_AddressType WHERE SystemIdentificator = 'PERNAMENT_ADDRESS'),@PersonId)
else 
UPDATE Shared_Address SET CountryId =@paCountry, 
Region =@paRegion,City =@paCity,Street=@paStreet,HouseNumber=@paHouseNumber,ZipCode = @paZipCode 
WHERE Id = @PernamentAddressId


if (@MailingAddressId IS NULL)
INSERT Shared_Address (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,CountryId,Region,City,Street,HouseNumber,ZipCode,AddressTypeId,PersonId)
VALUES (NEWID(),0,0,1,null,@paCountry,@paRegion,@paCity,@paStreet,@paHouseNumber,@paZipCode,(SELECT Id FROM Cb_AddressType WHERE SystemIdentificator = 'MAILING_ADDRESS'),@PersonId)
else 
UPDATE Shared_Address SET CountryId =@maCountry, 
Region =@maRegion,City =@maCity,Street=@maStreet,HouseNumber=@maHouseNumber,ZipCode = @maZipCode 
WHERE Id = @MailingAddressId
 



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
