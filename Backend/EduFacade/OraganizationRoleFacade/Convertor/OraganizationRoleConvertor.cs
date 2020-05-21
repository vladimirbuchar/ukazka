using Model.Functions.UserInOrganization;
using System;
using System.Collections.Generic;
using System.Text;
using WebModel.OrganizationDto;

namespace EduFacade.OraganizationRoleFacade.Convertor
{
    public interface IOraganizationRoleConvertor
    {
        GetUserOrganizationRoleDto ConvertToWebModel(List<GetUserOrganizationRole> getUserOrganizationRoles);
    }
}
