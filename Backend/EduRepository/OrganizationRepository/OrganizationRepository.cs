using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.License;
using Model.Functions.Organization;
using Model.Functions.Shared;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.OrganizationRepository
{
    public class OrganizationRepository : BaseRepository, IOrganizationRepository
    {
        public OrganizationRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }

        public Guid GetOrganizationIdByBranch(Guid branchId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByBranch", new List<SqlParameter>()
            {
                new SqlParameter("@branchId",branchId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationIdByClassRoom(Guid classRoomId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByClassRoom", new List<SqlParameter>()
            {
                new SqlParameter("@classRoomId",classRoomId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationByCourse(Guid courseId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByCourse", new List<SqlParameter>()
            {
                new SqlParameter("@courseId",courseId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationByTermId(Guid termId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByCourseTerm", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermId",termId)
            }).FirstOrDefault().Id;
        }
        public Guid GetOrganizationByCourseLessonId(Guid courseLessonId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByCourseLesson", new List<SqlParameter>()
            {
                new SqlParameter("@courseLessonId",courseLessonId)
            }).FirstOrDefault().Id;
        }

        public IEnumerable<GetAllOrganizations> GetAllOrganizations()
        {
            return CallSqlFunction<GetAllOrganizations>("GetAllOrganizations").OrderBy(x => x.Priority);
        }

        public IEnumerable<GetMyOrganizations> GetMyOrganizations(Guid userId)
        {
            List<SqlParameter> param = new List<SqlParameter>
            {
                new SqlParameter("@userId", userId)
            };
            return CallSqlFunction<GetMyOrganizations>("GetMyOrganization", param).ToList();
        }
        public GetOrganizationDetail GetOrganizationDetail(Guid organizationId)
        {
            List<SqlParameter> param = new List<SqlParameter>
            {
                new SqlParameter("@organizationId", organizationId)
            };
            return CallSqlFunction<GetOrganizationDetail>("GetOrganizationDetail", param).FirstOrDefault();
        }

        public HashSet<GetOrganizationAddress> GetOrganizationAddress(Guid organizationId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@organizationId", organizationId)
            };
            return CallSqlFunction<GetOrganizationAddress>("GetOrganizationAddress", parameters).ToHashSet();
        }

        public GetLicenseByOrganization GetLicenseByOrganization(Guid organizationId)
        {
            return CallSqlFunction<GetLicenseByOrganization>("GetLicenseByOrganization", new List<SqlParameter>()
            {
                new SqlParameter("@organizationId",organizationId)
            }).FirstOrDefault();
        }

        public Guid GetOrganizationByUserInOrganization(Guid id)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByUserInOrganization", new List<SqlParameter>()
            {
                new SqlParameter("@id",id)
            }).FirstOrDefault().Id;
        }

        public Guid AddOrganization(AddOrganization addOrganization)
        {
            Guid organizationGuid = Guid.Empty;
            FAddress address = addOrganization.Addresses.FirstOrDefault(x => x.AddressTypeIdentificator == AddressTypeValues.REGISTERED_OFFICE_ADDRESS);
            FAddress billingAddress = addOrganization.Addresses.FirstOrDefault(x => x.AddressTypeIdentificator == AddressTypeValues.BILLING_ADDRESS);
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CanSendCourseInquiry", addOrganization.CanSendCourseInquiry),
                new SqlParameter("@LicenseIdentificator", addOrganization.LicenseIdentificator),
                new SqlParameter("@ContactInformationEmail", addOrganization.ContactInformationEmail),
                new SqlParameter("@ContactInformationPhoneNumber", addOrganization.ContactInformationPhoneNumber),
                new SqlParameter("@ContactInformationWWW", addOrganization.ContactInformationWWW),
                new SqlParameter("@BasicInformationName", addOrganization.BasicInformationName),
                new SqlParameter("@BasicInformationDescription", addOrganization.BasicInformationDescription),
                new SqlParameter("@UserId", addOrganization.UserId),
                new SqlParameter("@OrganizationRoleIdentificator", addOrganization.OrganizationRoleIdentificator),
                new SqlParameter("@addressCountry",address.CountryId),
                new SqlParameter("@addressRegion",address.Region),
                new SqlParameter("@addressCity",address.City),
                new SqlParameter("@addressStreet",address.Street),
                new SqlParameter("@addressHouseNumber",address.HouseNumber),
                new SqlParameter("@addressZipCode",address.ZipCode),
                new SqlParameter("@addressTypeId",address.AddressTypeId),
                new SqlParameter("@addressCountryContact",billingAddress.CountryId),
                new SqlParameter("@addressRegionContact",billingAddress.Region),
                new SqlParameter("@addressCityContact",billingAddress.City),
                new SqlParameter("@addressStreetContact",billingAddress.Street),
                new SqlParameter("@addressHouseNumberContact",billingAddress.HouseNumber),
                new SqlParameter("@addressZipCodeContact",billingAddress.ZipCode),
                new SqlParameter("@addressTypeIdContact",billingAddress.AddressTypeId),
            };

            CallSqlProcedure("CreateOrganization", sqlParameters, true, ref organizationGuid);
            return organizationGuid;

        }
        public void UpdateOrganization(UpdateOrganization updateOrganization)
        {
            FAddress address = updateOrganization.Addresses.FirstOrDefault(x => x.AddressTypeIdentificator == AddressTypeValues.REGISTERED_OFFICE_ADDRESS);
            FAddress billingAddress = updateOrganization.Addresses.FirstOrDefault(x => x.AddressTypeIdentificator == AddressTypeValues.BILLING_ADDRESS);
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@OrganizationId",updateOrganization.OrganizationId),
                new SqlParameter("@CanSendCourseInquiry", updateOrganization.CanSendCourseInquiry),
                new SqlParameter("@ContactInformationEmail", updateOrganization.ContactInformationEmail),
                new SqlParameter("@ContactInformationPhoneNumber", updateOrganization.ContactInformationPhoneNumber),
                new SqlParameter("@ContactInformationWWW", updateOrganization.ContactInformationWWW),
                new SqlParameter("@BasicInformationName", updateOrganization.BasicInformationName),
                new SqlParameter("@BasicInformationDescription", updateOrganization.BasicInformationDescription),

                new SqlParameter("@addressCountry",address.CountryId),
                new SqlParameter("@addressRegion",address.Region),
                new SqlParameter("@addressCity",address.City),
                new SqlParameter("@addressStreet",address.Street),
                new SqlParameter("@addressHouseNumber",address.HouseNumber),
                new SqlParameter("@addressZipCode",address.ZipCode),
                new SqlParameter("@addressTypeId",address.AddressTypeId),
                new SqlParameter("@addressCountryContact",billingAddress.CountryId),
                new SqlParameter("@addressRegionContact",billingAddress.Region),
                new SqlParameter("@addressCityContact",billingAddress.City),
                new SqlParameter("@addressStreetContact",billingAddress.Street),
                new SqlParameter("@addressHouseNumberContact",billingAddress.HouseNumber),
                new SqlParameter("@addressZipCodeContact",billingAddress.ZipCode),
                new SqlParameter("@addressTypeIdContact",billingAddress.AddressTypeId),
            };
            CallSqlProcedure("UpdateOrganization", sqlParameters);
        }

        public List<FindOrganization> FindOrganization(string findText)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@findText", findText)
            };
            return CallSqlFunction<FindOrganization>("FindOrganization", sqlParameters).OrderBy(x => x.Id).ToList();
        }

        public Guid GetOrganizationByCourseLessonItemId(Guid courseLessonItemId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByCourseLessonItem", new List<SqlParameter>()
            {
                new SqlParameter("@courseLessonItemId",courseLessonItemId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationIdByBankOfQuestion(Guid bankOfQuestionId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByBankOfQuestion", new List<SqlParameter>()
            {
                new SqlParameter("@BankOfQuestionId",bankOfQuestionId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationIdByQuestion(Guid questionId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationIdByQuestion", new List<SqlParameter>()
            {
                new SqlParameter("@BankOfQuestionId",questionId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationByAnswer(Guid answerId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationIdByAnswer", new List<SqlParameter>()
            {
                new SqlParameter("@answerId",answerId)
            }).FirstOrDefault().Id;
        }
    }
}
