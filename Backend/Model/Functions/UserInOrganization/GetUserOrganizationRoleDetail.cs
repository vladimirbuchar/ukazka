using System;

namespace Model.Functions.UserInOrganization
{
    public class GetUserOrganizationRoleDetail : SqlFunction
    {
        public Guid OrganizationRoleId { get; set; }
    }
}
