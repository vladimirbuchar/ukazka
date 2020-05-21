using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.OrganizationDto;

namespace EduFacade.OrganizationFacade
{
    public interface IOrganizationFacade : IBaseFacade
    {
        GetOrganizationDetailDto GetOrganizationDetail(Guid organizationId);
        GetOrganizationDetailWebDto GetOrganizationDetailWeb(Guid organizationId);
        Result AddOrganization(Guid userId, AddOrganizationDto addOrganizationDto);
        void DeleteOrganization(Guid ogranizationId);
        IEnumerable<GetMyOrganizationsDto> GetMyOrganizations(Guid userId);
        Result UpdateOrganization(UpdateOrganizationDto updateOrganizationDto);
        IEnumerable<GetOrganizationListDto> GetOrganizationList();
        void AddUserToOrganization(AddUserToOrganizationDto addUserToOrganizationDto);
        List<GetAllUserInOrganizationDto> GetAllUserInOrganization(Guid organizationId);
        void DeleteUserFromOrganization(Guid userInOrganizationId);
        List<FindOrganizationDto> FindOrganization(string findText);
        HashSet<GetOrganizationRolesDto> GetOrganizationRoles();
        GetUserOrganizationRoleDetailDto GetUserOrganizationRoleDetail(Guid userInOrganizationId);
        void UpdateUserInOrganizationRole(UpdateUserInOrganizationRoleDto updateUserInOrganizationRoleDto);
    }
}
