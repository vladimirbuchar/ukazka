using Model.Functions.UserInOrganization;
using System;
using System.Collections.Generic;
namespace EduRepository.OrganizationRoleRepository
{
    public interface IOrganizationRoleRepository : IBaseRepository
    {
        List<GetUserOrganizationRole> GetUserOrganizationRole(Guid userId, Guid organizationId);
        List<GetAllUserInOrganization> GetAllUserInOrganization(Guid organizationId);
        void AddUserToOrganization(AddUserToOrganization addUserToOrganization);
        GetUserOrganizationRoleDetail GetUserOrganizationRoleDetail(Guid userInOrganizationId);
        void UpdateUserInOrganizationRole(UpdateUserInOrganizationRole updateUserInOrganizationRole);
    }
}
