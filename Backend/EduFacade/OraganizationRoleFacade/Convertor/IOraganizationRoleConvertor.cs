using Model.Functions.UserInOrganization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebModel.OrganizationDto;

namespace EduFacade.OraganizationRoleFacade.Convertor
{
    public class OraganizationRoleConvertor : IOraganizationRoleConvertor
    {
        public GetUserOrganizationRoleDto ConvertToWebModel(List<GetUserOrganizationRole> getUserOrganizationRoles)
        {
            return  new GetUserOrganizationRoleDto()
            {
                IsCourseAdministrator = getUserOrganizationRoles.FirstOrDefault(x=> x.IsCourseAdministrator()) != null,
                IsCourseEditor = getUserOrganizationRoles.FirstOrDefault(x => x.IsCourseEditor()) != null,
                IsLector = getUserOrganizationRoles.FirstOrDefault(x => x.IsLector()) != null,
                IsOrganizationAdministrator = getUserOrganizationRoles.FirstOrDefault(x => x.IsOrganizationAdministrator()) != null,
                IsOrganizationOwner = getUserOrganizationRoles.FirstOrDefault(x => x.IsOrganizationOwner()) != null,
                IsStudent = getUserOrganizationRoles.FirstOrDefault(x => x.IsStudent()) != null
            };
        }
    }
}
