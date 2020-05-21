using System;
using WebModel.Shared;

namespace WebModel.OrganizationDto
{
    public class GetMyOrganizationsDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsOrganizationOwner { get; set; }
        public bool IsOrganizationAdministrator { get; set; }
        public bool IsCourseAdministrator { get; set; }
        public bool IsCourseEditor { get; set; }
        public bool IsLector { get; set; }
        public bool IsStudent { get; set; }
        public Guid UserInOrganizationRoleId { get; set; }
    }
}