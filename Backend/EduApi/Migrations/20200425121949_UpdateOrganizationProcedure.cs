using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateOrganizationProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE  PROCEDURE UpdateOrganization
                    @OrganizationId uniqueidentifier,
                    @CanSendCourseInquiry bit,
                    @ContactInformationEmail nvarchar(max),
                    @ContactInformationPhoneNumber nvarchar(max), 
                    @ContactInformationWWW nvarchar(max), 
                    @BasicInformationName nvarchar(max), 
                    @BasicInformationDescription nvarchar(max)
                AS
                    BEGIN
                        SET NOCOUNT ON;
                        BEGIN TRY
                            BEGIN TRANSACTION
                                DECLARE @ContactInformationId uniqueidentifier
                                SET @ContactInformationId = (SELECT ContactInformationId FROM Edu_Organization WHERE Id = @OrganizationId AND IsDeleted = 0)

                                DECLARE @LicenseSendCourseInquiry bit
                                SET @LicenseSendCourseInquiry = (SELECT SendCourseInquiry FROM Cb_License WHERE  Id = (SELECT TOP(1) LicenseId From Edu_Organization WHERE Id = @OrganizationId) AND IsDeleted = 0) 

                                DECLARE @BasicInformationId uniqueidentifier
                                SET @BasicInformationId = (SELECT BasicInformationId FROM Edu_Organization WHERE Id = @OrganizationId AND IsDeleted = 0)

                                DECLARE @CanSendCourseInquiry_tmp bit;
                                SET @CanSendCourseInquiry_tmp = @CanSendCourseInquiry

                                IF @CanSendCourseInquiry = 1 AND @LicenseSendCourseInquiry = 0
                                begin
                                    SET @CanSendCourseInquiry_tmp = 0
                                End

                                UPDATE  Edu_Organization SET CanSendCourseInquiry = @CanSendCourseInquiry_tmp WHERE Id = @OrganizationId
                                Update Shared_ContactInformation SET PhoneNumber = @ContactInformationPhoneNumber, Email = @ContactInformationEmail, WWW = @ContactInformationWWW
                                WHERE Id = @ContactInformationId
                                UPDATE Shared_BasicInformation SET Name = @BasicInformationName, Description = @BasicInformationDescription WHERE Id = @BasicInformationId


                            COMMIT
                        END TRY
                        BEGIN CATCH
                            ROLLBACK
                        END CATCH
                    END 
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
