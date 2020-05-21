using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.Branch;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.BranchRepository
{
    public class BranchRepository : BaseRepository, IBranchRepository
    {
        public BranchRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }

        public IEnumerable<GetAllBranchInOrganization> GetAllBranchInOrganization(Guid organizationId)
        {
            return CallSqlFunction<GetAllBranchInOrganization>("GetAllBranchInOrganization", new List<SqlParameter>()
            {
                new SqlParameter("@organizationId",organizationId)
            });
        }

        public GetBranchDetail GetBranchDetail(Guid branchId)
        {
            return CallSqlFunction<GetBranchDetail>("GetBranchDetail", new List<SqlParameter>()
            {
                new SqlParameter("@branchId",branchId)
            }).FirstOrDefault();
        }

        public void AddBranch(AddBranch addBranch)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@IsMainBranch", addBranch.IsMainBranch),
                new SqlParameter("@OrganizationId", addBranch.OrganizationId),
                new SqlParameter("@ContactInformationEmail", addBranch.ContactInformationEmail),
                new SqlParameter("@ContactInformationPhoneNumber", addBranch.ContactInformationPhoneNumber),
                new SqlParameter("@ContactInformationWWW", addBranch.ContactInformationWWW),
                new SqlParameter("@BasicInformationName", addBranch.BasicInformationName),
                new SqlParameter("@BasicInformationDescription", addBranch.BasicInformationDescription),
                new SqlParameter("@AddressCountryId", addBranch.AddressCountryId),
                new SqlParameter("@AddressRegion", addBranch.AddressRegion),
                new SqlParameter("@AddressCity", addBranch.AddressCity),
                new SqlParameter("@AddressStreet", addBranch.AddressStreet),
                new SqlParameter("@AddressHouseNumber", addBranch.AddressHouseNumber),
                new SqlParameter("@AddressZipCode", addBranch.AddressZipCode)
            };
            CallSqlProcedure("CreateBranch", sqlParameters);
        }
        public void UpdateBranch(UpdateBranch updateBranch)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@IsMainBranch", updateBranch.IsMainBranch),
                new SqlParameter("@BranchId", updateBranch.Id),
                new SqlParameter("@ContactInformationEmail", updateBranch.ContactInformationEmail),
                new SqlParameter("@ContactInformationPhoneNumber", updateBranch.ContactInformationPhoneNumber),
                new SqlParameter("@ContactInformationWWW", updateBranch.ContactInformationWWW),
                new SqlParameter("@BasicInformationName", updateBranch.BasicInformationName),
                new SqlParameter("@BasicInformationDescription", updateBranch.BasicInformationDescription),
                new SqlParameter("@AddressCountryId", updateBranch.AddressCountryId),
                new SqlParameter("@AddressRegion", updateBranch.AddressRegion),
                new SqlParameter("@AddressCity", updateBranch.AddressCity),
                new SqlParameter("@AddressStreet", updateBranch.AddressStreet),
                new SqlParameter("@AddressHouseNumber", updateBranch.AddressHouseNumber),
                new SqlParameter("@AddressZipCode", updateBranch.AddressZipCode)
            };
            CallSqlProcedure("UpdateBranch", sqlParameters);
        }
    }
}
