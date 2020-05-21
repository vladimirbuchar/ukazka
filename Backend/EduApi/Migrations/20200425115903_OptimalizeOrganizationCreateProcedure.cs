using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class OptimalizeOrganizationCreateProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string query = @"ALTER PROCEDURE [dbo].[CreateOrganization] 
                         @CanSendCourseInquiry bit 
                        ,@ContactInformationEmail nvarchar(max) 
                        ,@ContactInformationPhoneNumber nvarchar(max) 
                        ,@ContactInformationWWW nvarchar(max) 
                        ,@BasicInformationName nvarchar(max) 
                        ,@BasicInformationDescription nvarchar(max) 
                        ,@UserId uniqueidentifier 
                        ,@OrganizationRoleIdentificator nvarchar(max) 
                        ,@LicenseIdentificator nvarchar(max) 

                        AS 
                        BEGIN 
                            SET NOCOUNT ON; 
                            BEGIN TRY
                                BEGIN TRANSACTION
                                    DECLARE @Edu_Organization_id uniqueidentifier 
                                    SET @Edu_Organization_id  = NEWID() 
                                    DECLARE @ContactInformationId uniqueidentifier 
                                    SET @ContactInformationId  = NEWID(); 
                                    DECLARE @LicenseSendCourseInquiry bit
                                    SET @LicenseSendCourseInquiry = (SELECT SendCourseInquiry FROM Cb_License WHERE SystemIdentificator = @LicenseIdentificator AND IsDeleted = 0) 
                                    DECLARE @BasicInformationId uniqueidentifier 
                                    SET @BasicInformationId  = NEWID(); 
                                    DECLARE @OrganizationRoleId uniqueidentifier
                                    SET @OrganizationRoleId = (SELECT Id FROM Edu_OrganizationRole WHERE SystemIdentificator = @OrganizationRoleIdentificator AND IsDeleted = 0) 
                                    DECLARE @LicenseId uniqueidentifier
                                    SET @LicenseId = (SELECT Id FROM Cb_License WHERE SystemIdentificator = @LicenseIdentificator AND IsDeleted = 0) 
                                    DECLARE @CanSendCourseInquiry_tmp bit;
                                    SET @CanSendCourseInquiry_tmp = @CanSendCourseInquiry


                                    IF @CanSendCourseInquiry = 1 AND @LicenseSendCourseInquiry = 0
                                    begin
                                    SET @CanSendCourseInquiry_tmp = 0
                                    End

                                    INSERT INTO Shared_ContactInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Email,PhoneNumber,WWW) VALUES 
                                    (@ContactInformationId,0,0,1,null,@ContactInformationEmail,@ContactInformationPhoneNumber,@ContactInformationWWW);


                                    INSERT INTO Shared_BasicInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Name,Description) VALUES 
                                    (@BasicInformationId,0,0,1,null,@BasicInformationName,@BasicInformationDescription);

                                    INSERT INTO Edu_Organization 
                                    (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, CanSendCourseInquiry, ContactInformationId, BasicInformationId,LicenseId) VALUES 
                                    (@Edu_Organization_id, 0, 0, 1, null, @CanSendCourseInquiry_tmp, @ContactInformationId, @BasicInformationId,@LicenseId); 

                                    INSERT INTO Link_UserInOrganization 
                                    (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, OrganizationId, OrganizationRoleId, UserId) VALUES 
                                    (NEWID(), 0, 0, 1, null, @Edu_Organization_id, @OrganizationRoleId, @UserId); 


                                COMMIT
                            END TRY
                            BEGIN CATCH
                                ROLLBACK
                            END CATCH
                        END ";
            migrationBuilder.Sql(query);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
