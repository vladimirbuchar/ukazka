using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.UserInOrganization;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace EduRepository.OrganizationRoleRepository
{
    public class OrganizationRoleRepository : BaseRepository, IOrganizationRoleRepository
    {
        public OrganizationRoleRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }



        public void AddUserToOrganization(AddUserToOrganization addUserToOrganization)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@OrganizationId", addUserToOrganization.OrganizationId),
                new SqlParameter("@OrganizationRoleId", addUserToOrganization.OrganizationRoleId),
                new SqlParameter("@UserId", addUserToOrganization.UserId)
            };
            CallSqlProcedure("AddUserToOrganization", sqlParameters);
        }


        public List<GetUserOrganizationRole> GetUserOrganizationRole(Guid userId, Guid organizationId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@userId", userId),
                new SqlParameter("@organizationId", organizationId)
            };
            return CallSqlFunction<GetUserOrganizationRole>("GetUserOrganizationRole", sqlParam).ToList();

        }

        public List<GetAllUserInOrganization> GetAllUserInOrganization(Guid organizationId)
        {
            return CallSqlFunction<GetAllUserInOrganization>("GetAllUserInOrganization", new List<SqlParameter>()
            {
                new SqlParameter("@organizationId",organizationId)
            }).ToList();
        }

        public GetUserOrganizationRoleDetail GetUserOrganizationRoleDetail(Guid userInOrganizationId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@userInOrganizationId", userInOrganizationId)
            };
            return CallSqlFunction<GetUserOrganizationRoleDetail>("GetUserOrganizationRoleDetail", sqlParameters).FirstOrDefault();
        }

        public void UpdateUserInOrganizationRole(UpdateUserInOrganizationRole updateUserInOrganizationRole)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@OrganizationRoleId", updateUserInOrganizationRole.OrganizationRoleId),
                new SqlParameter("@Id", updateUserInOrganizationRole.Id)
            };
            CallSqlProcedure("UpdateUserInOrganizationRole", sqlParameters);
        }
    }
}
