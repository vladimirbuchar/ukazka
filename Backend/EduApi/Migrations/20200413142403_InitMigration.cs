using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cb_AddressType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_AddressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cb_Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cb_CourseStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_CourseStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cb_CourseType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_CourseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cb_Culture",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_Culture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cb_Email",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    EmailBodyHtml = table.Column<string>(nullable: true),
                    EmailBodyPlainText = table.Column<string>(nullable: true),
                    IsHtml = table.Column<bool>(nullable: false),
                    From = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_Email", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cb_License",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    MaximumBranch = table.Column<int>(nullable: false),
                    MaximumCourse = table.Column<int>(nullable: false),
                    CreatePrivateCourse = table.Column<bool>(nullable: false),
                    MaximumStudents = table.Column<int>(nullable: false),
                    MaximumLectors = table.Column<int>(nullable: false),
                    MounthPrice = table.Column<double>(nullable: false),
                    OneYearSale = table.Column<double>(nullable: false),
                    OneYearPrice = table.Column<double>(nullable: false),
                    Support = table.Column<bool>(nullable: false),
                    SendCourseInquiry = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_License", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cb_TimeTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_TimeTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Edu_Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Link_CourseCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_CourseCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Link_CourseLector",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    UserInOrganizationId = table.Column<Guid>(nullable: false),
                    CourseTermId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_CourseLector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Link_CourseStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    CourseTermId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_CourseStudent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shared_BasicInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shared_BasicInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shared_CoursePrice",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Sale = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shared_CoursePrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shared_StudentCount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    MinimumStudent = table.Column<int>(nullable: false),
                    MaximumStudent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shared_StudentCount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "System_DataMigration",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    ExcelName = table.Column<string>(nullable: true),
                    ExcelLastModification = table.Column<DateTime>(nullable: false),
                    FolderLastModification = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ErrorMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System_DataMigration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "System_ObjectHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    ObjectId = table.Column<Guid>(nullable: false),
                    OldValue = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true),
                    ObjectType = table.Column<string>(nullable: true),
                    EventType = table.Column<string>(nullable: true),
                    ActionTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System_ObjectHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shared_Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    AddressTypeId = table.Column<Guid>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shared_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shared_Address_Edu_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Edu_Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shared_Address_Cb_AddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "Cb_AddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shared_Address_Cb_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Cb_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Link_UserInOrganization",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    OrganizationRoleId = table.Column<Guid>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    CourseLectorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_UserInOrganization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_UserInOrganization_Link_CourseLector_CourseLectorId",
                        column: x => x.CourseLectorId,
                        principalTable: "Link_CourseLector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: true),
                    CourseCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Category_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Category_Edu_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Edu_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Category_Link_CourseCategory_CourseCategoryId",
                        column: x => x.CourseCategoryId,
                        principalTable: "Link_CourseCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_Slider",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Slider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Slider_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_UserRole_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    LicenseId = table.Column<Guid>(nullable: true),
                    CanSendCourseInquiry = table.Column<bool>(nullable: false),
                    UserInOrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Organization_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Organization_Cb_License_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Cb_License",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Organization_Link_UserInOrganization_UserInOrganizationId",
                        column: x => x.UserInOrganizationId,
                        principalTable: "Link_UserInOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_OrganizationRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    UserInOrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_OrganizationRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationRole_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationRole_Link_UserInOrganization_UserInOrganizationId",
                        column: x => x.UserInOrganizationId,
                        principalTable: "Link_UserInOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    UserEmail = table.Column<string>(nullable: true),
                    UserPassword = table.Column<string>(nullable: true),
                    UserToken = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: true),
                    UserRoleId = table.Column<Guid>(nullable: true),
                    CourseStudentId = table.Column<Guid>(nullable: true),
                    ObjectHistoryId = table.Column<Guid>(nullable: true),
                    UserInOrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_User_Link_CourseStudent_CourseStudentId",
                        column: x => x.CourseStudentId,
                        principalTable: "Link_CourseStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_User_System_ObjectHistory_ObjectHistoryId",
                        column: x => x.ObjectHistoryId,
                        principalTable: "System_ObjectHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_User_Edu_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Edu_Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_User_Link_UserInOrganization_UserInOrganizationId",
                        column: x => x.UserInOrganizationId,
                        principalTable: "Link_UserInOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_User_Edu_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "Edu_UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_Course",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    CoursePriceId = table.Column<Guid>(nullable: true),
                    StudentCountId = table.Column<Guid>(nullable: true),
                    CourseTypeId = table.Column<Guid>(nullable: true),
                    CourseStatusId = table.Column<Guid>(nullable: true),
                    IsPrivateCourse = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: true),
                    CourseCategoryId = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Course_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Course_Edu_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Edu_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Course_Link_CourseCategory_CourseCategoryId",
                        column: x => x.CourseCategoryId,
                        principalTable: "Link_CourseCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Course_Shared_CoursePrice_CoursePriceId",
                        column: x => x.CoursePriceId,
                        principalTable: "Shared_CoursePrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Course_Cb_CourseStatus_CourseStatusId",
                        column: x => x.CourseStatusId,
                        principalTable: "Cb_CourseStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Course_Cb_CourseType_CourseTypeId",
                        column: x => x.CourseTypeId,
                        principalTable: "Cb_CourseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Course_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Course_Shared_StudentCount_StudentCountId",
                        column: x => x.StudentCountId,
                        principalTable: "Shared_StudentCount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_Job",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    Salary = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Job_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Job_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shared_ContactInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    WWW = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shared_ContactInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shared_ContactInformation_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_OrganizationRolePermition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    OrganizationRoleId = table.Column<Guid>(nullable: true),
                    PermitionIdentificator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_OrganizationRolePermition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationRolePermition_Edu_OrganizationRole_OrganizationRoleId",
                        column: x => x.OrganizationRoleId,
                        principalTable: "Edu_OrganizationRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_Inquiry",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    ContactPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Inquiry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Inquiry_Edu_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_LectorRate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    LectorId = table.Column<Guid>(nullable: true),
                    StudentId = table.Column<Guid>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    BasicInformationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_LectorRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_LectorRate_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_LectorRate_Edu_User_LectorId",
                        column: x => x.LectorId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_LectorRate_Edu_User_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Link_UserInRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    UserRoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_UserInRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_UserInRole_Edu_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_UserInRole_Edu_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "Edu_UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_CourseLesson",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    CourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseLesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseLesson_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseLesson_Edu_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Edu_Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_CourseRate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    CourseId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    RateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    OldRateId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseRate_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseRate_Edu_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Edu_Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseRate_Edu_CourseRate_OldRateId",
                        column: x => x.OldRateId,
                        principalTable: "Edu_CourseRate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseRate_Edu_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_CourseTest",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    IsRandomGenerateQuestion = table.Column<bool>(nullable: false),
                    QuestionCountInTest = table.Column<int>(nullable: false),
                    TimeLimit = table.Column<int>(nullable: false),
                    DesiredSuccess = table.Column<int>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseTest_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseTest_Edu_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Edu_Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shared_Gallery",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    GalleryItemTypeId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shared_Gallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shared_Gallery_Edu_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Edu_Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_Branch",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true),
                    ContactInformationsId = table.Column<Guid>(nullable: true),
                    IsMainBranch = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Branch_Shared_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Shared_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Branch_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Branch_Shared_ContactInformation_ContactInformationsId",
                        column: x => x.ContactInformationsId,
                        principalTable: "Shared_ContactInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_CourseItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    Html = table.Column<string>(nullable: true),
                    CourseLessonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseItem_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseItem_Edu_CourseLesson_CourseLessonId",
                        column: x => x.CourseLessonId,
                        principalTable: "Edu_CourseLesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_StudentTestSummary",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    Score = table.Column<double>(nullable: false),
                    Finish = table.Column<DateTime>(nullable: true),
                    TestCompleted = table.Column<bool>(nullable: false),
                    CourseTestId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_StudentTestSummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummary_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummary_Edu_CourseTest_CourseTestId",
                        column: x => x.CourseTestId,
                        principalTable: "Edu_CourseTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummary_Edu_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_TestQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    AnswerMode = table.Column<string>(nullable: true),
                    CourseTestId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_TestQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_TestQuestion_Edu_CourseTest_CourseTestId",
                        column: x => x.CourseTestId,
                        principalTable: "Edu_CourseTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_TestStudentResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    CourseTestId = table.Column<Guid>(nullable: true),
                    Result = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_TestStudentResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_TestStudentResult_Edu_CourseTest_CourseTestId",
                        column: x => x.CourseTestId,
                        principalTable: "Edu_CourseTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_TestStudentResult_Edu_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cb_GalleryItemType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    GalleryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_GalleryItemType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cb_GalleryItemType_Shared_Gallery_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Shared_Gallery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_ClassRoom",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    Floor = table.Column<int>(nullable: false),
                    MaxCapacity = table.Column<int>(nullable: false),
                    BranchId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_ClassRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_ClassRoom_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_ClassRoom_Edu_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Edu_Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_TestQuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    IsTrueAnswer = table.Column<bool>(nullable: false),
                    TestQuestionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_TestQuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_TestQuestionAnswer_Edu_TestQuestion_TestQuestionId",
                        column: x => x.TestQuestionId,
                        principalTable: "Edu_TestQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_CourseTerm",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    StudentCountId = table.Column<Guid>(nullable: true),
                    CoursePriceId = table.Column<Guid>(nullable: true),
                    TimeFromId = table.Column<Guid>(nullable: true),
                    TimeToId = table.Column<Guid>(nullable: true),
                    ActiveFrom = table.Column<DateTime>(nullable: true),
                    ActiveTo = table.Column<DateTime>(nullable: true),
                    RegistrationFrom = table.Column<DateTime>(nullable: true),
                    RegistrationTo = table.Column<DateTime>(nullable: true),
                    Monday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Friday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false),
                    ClassRoomId = table.Column<Guid>(nullable: true),
                    CourseId = table.Column<Guid>(nullable: true),
                    CourseLectorId = table.Column<Guid>(nullable: true),
                    CourseStudentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseTerm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseTerm_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseTerm_Edu_ClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "Edu_ClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseTerm_Edu_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Edu_Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseTerm_Link_CourseLector_CourseLectorId",
                        column: x => x.CourseLectorId,
                        principalTable: "Link_CourseLector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseTerm_Shared_CoursePrice_CoursePriceId",
                        column: x => x.CoursePriceId,
                        principalTable: "Shared_CoursePrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseTerm_Link_CourseStudent_CourseStudentId",
                        column: x => x.CourseStudentId,
                        principalTable: "Link_CourseStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseTerm_Shared_StudentCount_StudentCountId",
                        column: x => x.StudentCountId,
                        principalTable: "Shared_StudentCount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseTerm_Cb_TimeTable_TimeFromId",
                        column: x => x.TimeFromId,
                        principalTable: "Cb_TimeTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseTerm_Cb_TimeTable_TimeToId",
                        column: x => x.TimeToId,
                        principalTable: "Cb_TimeTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cb_AddressType_SystemIdentificator",
                table: "Cb_AddressType",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_CourseStatus_SystemIdentificator",
                table: "Cb_CourseStatus",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_CourseType_SystemIdentificator",
                table: "Cb_CourseType",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_Culture_SystemIdentificator",
                table: "Cb_Culture",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_Email_SystemIdentificator",
                table: "Cb_Email",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_GalleryItemType_GalleryId",
                table: "Cb_GalleryItemType",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_GalleryItemType_SystemIdentificator",
                table: "Cb_GalleryItemType",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_License_SystemIdentificator",
                table: "Cb_License",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_TimeTable_SystemIdentificator",
                table: "Cb_TimeTable",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Branch_AddressId",
                table: "Edu_Branch",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Branch_BasicInformationId",
                table: "Edu_Branch",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Branch_ContactInformationsId",
                table: "Edu_Branch",
                column: "ContactInformationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Branch_SystemIdentificator",
                table: "Edu_Branch",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Category_BasicInformationId",
                table: "Edu_Category",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Category_CategoryId",
                table: "Edu_Category",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Category_CourseCategoryId",
                table: "Edu_Category",
                column: "CourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Category_SystemIdentificator",
                table: "Edu_Category",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_ClassRoom_BasicInformationId",
                table: "Edu_ClassRoom",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_ClassRoom_BranchId",
                table: "Edu_ClassRoom",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_ClassRoom_SystemIdentificator",
                table: "Edu_ClassRoom",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Course_BasicInformationId",
                table: "Edu_Course",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Course_CategoryId",
                table: "Edu_Course",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Course_CourseCategoryId",
                table: "Edu_Course",
                column: "CourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Course_CoursePriceId",
                table: "Edu_Course",
                column: "CoursePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Course_CourseStatusId",
                table: "Edu_Course",
                column: "CourseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Course_CourseTypeId",
                table: "Edu_Course",
                column: "CourseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Course_OrganizationId",
                table: "Edu_Course",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Course_StudentCountId",
                table: "Edu_Course",
                column: "StudentCountId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Course_SystemIdentificator",
                table: "Edu_Course",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseItem_BasicInformationId",
                table: "Edu_CourseItem",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseItem_CourseLessonId",
                table: "Edu_CourseItem",
                column: "CourseLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseItem_SystemIdentificator",
                table: "Edu_CourseItem",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLesson_BasicInformationId",
                table: "Edu_CourseLesson",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLesson_CourseId",
                table: "Edu_CourseLesson",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseRate_BasicInformationId",
                table: "Edu_CourseRate",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseRate_CourseId",
                table: "Edu_CourseRate",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseRate_OldRateId",
                table: "Edu_CourseRate",
                column: "OldRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseRate_SystemIdentificator",
                table: "Edu_CourseRate",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseRate_UserId",
                table: "Edu_CourseRate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_BasicInformationId",
                table: "Edu_CourseTerm",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_ClassRoomId",
                table: "Edu_CourseTerm",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_CourseId",
                table: "Edu_CourseTerm",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_CourseLectorId",
                table: "Edu_CourseTerm",
                column: "CourseLectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_CoursePriceId",
                table: "Edu_CourseTerm",
                column: "CoursePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_CourseStudentId",
                table: "Edu_CourseTerm",
                column: "CourseStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_StudentCountId",
                table: "Edu_CourseTerm",
                column: "StudentCountId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_SystemIdentificator",
                table: "Edu_CourseTerm",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_TimeFromId",
                table: "Edu_CourseTerm",
                column: "TimeFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_TimeToId",
                table: "Edu_CourseTerm",
                column: "TimeToId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTest_BasicInformationId",
                table: "Edu_CourseTest",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTest_CourseId",
                table: "Edu_CourseTest",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTest_SystemIdentificator",
                table: "Edu_CourseTest",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Inquiry_SystemIdentificator",
                table: "Edu_Inquiry",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Inquiry_UserId",
                table: "Edu_Inquiry",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Job_BasicInformationId",
                table: "Edu_Job",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Job_OrganizationId",
                table: "Edu_Job",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Job_SystemIdentificator",
                table: "Edu_Job",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_LectorRate_BasicInformationId",
                table: "Edu_LectorRate",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_LectorRate_LectorId",
                table: "Edu_LectorRate",
                column: "LectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_LectorRate_StudentId",
                table: "Edu_LectorRate",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_LectorRate_SystemIdentificator",
                table: "Edu_LectorRate",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Organization_BasicInformationId",
                table: "Edu_Organization",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Organization_LicenseId",
                table: "Edu_Organization",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Organization_SystemIdentificator",
                table: "Edu_Organization",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Organization_UserInOrganizationId",
                table: "Edu_Organization",
                column: "UserInOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationRole_BasicInformationId",
                table: "Edu_OrganizationRole",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationRole_SystemIdentificator",
                table: "Edu_OrganizationRole",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationRole_UserInOrganizationId",
                table: "Edu_OrganizationRole",
                column: "UserInOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationRolePermition_OrganizationRoleId",
                table: "Edu_OrganizationRolePermition",
                column: "OrganizationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationRolePermition_SystemIdentificator",
                table: "Edu_OrganizationRolePermition",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Person_SystemIdentificator",
                table: "Edu_Person",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Slider_BasicInformationId",
                table: "Edu_Slider",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Slider_SystemIdentificator",
                table: "Edu_Slider",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummary_BasicInformationId",
                table: "Edu_StudentTestSummary",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummary_CourseTestId",
                table: "Edu_StudentTestSummary",
                column: "CourseTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummary_SystemIdentificator",
                table: "Edu_StudentTestSummary",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummary_UserId",
                table: "Edu_StudentTestSummary",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestQuestion_CourseTestId",
                table: "Edu_TestQuestion",
                column: "CourseTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestQuestion_SystemIdentificator",
                table: "Edu_TestQuestion",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestQuestionAnswer_SystemIdentificator",
                table: "Edu_TestQuestionAnswer",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestQuestionAnswer_TestQuestionId",
                table: "Edu_TestQuestionAnswer",
                column: "TestQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestStudentResult_CourseTestId",
                table: "Edu_TestStudentResult",
                column: "CourseTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestStudentResult_SystemIdentificator",
                table: "Edu_TestStudentResult",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestStudentResult_UserId",
                table: "Edu_TestStudentResult",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_User_CourseStudentId",
                table: "Edu_User",
                column: "CourseStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_User_ObjectHistoryId",
                table: "Edu_User",
                column: "ObjectHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_User_PersonId",
                table: "Edu_User",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_User_SystemIdentificator",
                table: "Edu_User",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_User_UserEmail",
                table: "Edu_User",
                column: "UserEmail",
                unique: true,
                filter: "[UserEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_User_UserInOrganizationId",
                table: "Edu_User",
                column: "UserInOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_User_UserRoleId",
                table: "Edu_User",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_UserRole_BasicInformationId",
                table: "Edu_UserRole",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_UserRole_SystemIdentificator",
                table: "Edu_UserRole",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseCategory_SystemIdentificator",
                table: "Link_CourseCategory",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseLector_SystemIdentificator",
                table: "Link_CourseLector",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseStudent_SystemIdentificator",
                table: "Link_CourseStudent",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Link_UserInOrganization_CourseLectorId",
                table: "Link_UserInOrganization",
                column: "CourseLectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_UserInOrganization_SystemIdentificator",
                table: "Link_UserInOrganization",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Link_UserInRole_SystemIdentificator",
                table: "Link_UserInRole",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Link_UserInRole_UserId",
                table: "Link_UserInRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_UserInRole_UserRoleId",
                table: "Link_UserInRole",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Shared_Address_PersonId",
                table: "Shared_Address",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Shared_Address_AddressTypeId",
                table: "Shared_Address",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shared_Address_CountryId",
                table: "Shared_Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Shared_Address_SystemIdentificator",
                table: "Shared_Address",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Shared_BasicInformation_SystemIdentificator",
                table: "Shared_BasicInformation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Shared_ContactInformation_OrganizationId",
                table: "Shared_ContactInformation",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Shared_ContactInformation_SystemIdentificator",
                table: "Shared_ContactInformation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Shared_CoursePrice_SystemIdentificator",
                table: "Shared_CoursePrice",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Shared_Gallery_CourseId",
                table: "Shared_Gallery",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Shared_Gallery_SystemIdentificator",
                table: "Shared_Gallery",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Shared_StudentCount_SystemIdentificator",
                table: "Shared_StudentCount",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_System_DataMigration_SystemIdentificator",
                table: "System_DataMigration",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_System_ObjectHistory_SystemIdentificator",
                table: "System_ObjectHistory",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cb_Culture");

            migrationBuilder.DropTable(
                name: "Cb_Email");

            migrationBuilder.DropTable(
                name: "Cb_GalleryItemType");

            migrationBuilder.DropTable(
                name: "Edu_CourseItem");

            migrationBuilder.DropTable(
                name: "Edu_CourseRate");

            migrationBuilder.DropTable(
                name: "Edu_CourseTerm");

            migrationBuilder.DropTable(
                name: "Edu_Inquiry");

            migrationBuilder.DropTable(
                name: "Edu_Job");

            migrationBuilder.DropTable(
                name: "Edu_LectorRate");

            migrationBuilder.DropTable(
                name: "Edu_OrganizationRolePermition");

            migrationBuilder.DropTable(
                name: "Edu_Slider");

            migrationBuilder.DropTable(
                name: "Edu_StudentTestSummary");

            migrationBuilder.DropTable(
                name: "Edu_TestQuestionAnswer");

            migrationBuilder.DropTable(
                name: "Edu_TestStudentResult");

            migrationBuilder.DropTable(
                name: "Link_UserInRole");

            migrationBuilder.DropTable(
                name: "System_DataMigration");

            migrationBuilder.DropTable(
                name: "Shared_Gallery");

            migrationBuilder.DropTable(
                name: "Edu_CourseLesson");

            migrationBuilder.DropTable(
                name: "Edu_ClassRoom");

            migrationBuilder.DropTable(
                name: "Cb_TimeTable");

            migrationBuilder.DropTable(
                name: "Edu_OrganizationRole");

            migrationBuilder.DropTable(
                name: "Edu_TestQuestion");

            migrationBuilder.DropTable(
                name: "Edu_User");

            migrationBuilder.DropTable(
                name: "Edu_Branch");

            migrationBuilder.DropTable(
                name: "Edu_CourseTest");

            migrationBuilder.DropTable(
                name: "Link_CourseStudent");

            migrationBuilder.DropTable(
                name: "System_ObjectHistory");

            migrationBuilder.DropTable(
                name: "Edu_UserRole");

            migrationBuilder.DropTable(
                name: "Shared_Address");

            migrationBuilder.DropTable(
                name: "Shared_ContactInformation");

            migrationBuilder.DropTable(
                name: "Edu_Course");

            migrationBuilder.DropTable(
                name: "Edu_Person");

            migrationBuilder.DropTable(
                name: "Cb_AddressType");

            migrationBuilder.DropTable(
                name: "Cb_Country");

            migrationBuilder.DropTable(
                name: "Edu_Category");

            migrationBuilder.DropTable(
                name: "Shared_CoursePrice");

            migrationBuilder.DropTable(
                name: "Cb_CourseStatus");

            migrationBuilder.DropTable(
                name: "Cb_CourseType");

            migrationBuilder.DropTable(
                name: "Edu_Organization");

            migrationBuilder.DropTable(
                name: "Shared_StudentCount");

            migrationBuilder.DropTable(
                name: "Link_CourseCategory");

            migrationBuilder.DropTable(
                name: "Shared_BasicInformation");

            migrationBuilder.DropTable(
                name: "Cb_License");

            migrationBuilder.DropTable(
                name: "Link_UserInOrganization");

            migrationBuilder.DropTable(
                name: "Link_CourseLector");
        }
    }
}
