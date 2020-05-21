using System;
using WebModel.Shared;

namespace WebModel.OrganizationDto
{

    public class UpdateUserInOrganizationRoleDto : IBaseDtoWithUserAccessToken
    {
        public Guid Id { get; set; }
        public Guid OrganizationRoleId { get; set; }
        public string UserAccessToken { get; set; }
    }
}
