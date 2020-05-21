using System;

namespace Model.Functions.UserInOrganization
{
    public class AddUserToOrganization
    {
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid OrganizationRoleId { get; set; }
    }
}
