using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.OrganizationDto
{
    public class AddUserToOrganizationDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public List<string> UserEmails { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid OrganizationRoleId { get; set; }
        public string UserAccessToken { get; set; }
    }
}