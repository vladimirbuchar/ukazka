using Model.Functions.Organization;
using Model.Functions.UserInOrganization;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using WebModel.OrganizationDto;

namespace EduFacade.OrganizationFacade.Convertor
{
    public interface IOrganizationConvertor
    {
        AddOrganization ConvertToBussinessEntity(AddOrganizationDto addOrganizationDto, Guid userId);
        IEnumerable<GetMyOrganizationsDto> ConvertToWebModel(IEnumerable<GetMyOrganizations> getMyOrganizations);
        GetOrganizationDetailDto ConvertToWebModel(GetOrganizationDetail getOrganizationDetail, HashSet<GetOrganizationAddress> organizationAddresses);
        GetOrganizationDetailWebDto ConvertToWebModelWeb(GetOrganizationDetail getOrganizationDetail);
        UpdateOrganization ConvertToBussinessEntity(UpdateOrganizationDto updateOrganizationDto);
        IEnumerable<GetOrganizationListDto> ConvertToWebModel(IEnumerable<GetAllOrganizations> getAllOrganizations);
        List<FindOrganizationDto> ConvertToWebModel(List<FindOrganization> findOrganizations);
        AddUserToOrganization ConvertToBussinessEntity(AddUserToOrganizationDto adUserToOrganizationDto);
        List<GetAllUserInOrganizationDto> ConvertToWebModel(List<GetAllUserInOrganization> getAllUserInOrganizations);
        HashSet<GetOrganizationRolesDto> ConvertToWebModel(HashSet<OrganizationRole> organizationRoles);
        UpdateUserInOrganizationRole ConvertToBussinessEntity(UpdateUserInOrganizationRoleDto adUserToOrganizationDto);
    }
}
