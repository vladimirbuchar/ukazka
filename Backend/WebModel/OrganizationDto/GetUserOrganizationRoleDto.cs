using System;
using System.Collections.Generic;
using System.Text;

namespace WebModel.OrganizationDto
{
    public class GetUserOrganizationRoleDto
    {
        public bool IsOrganizationOwner { get; set; }
        public bool IsOrganizationAdministrator{ get; set; }
        public bool IsCourseAdministrator { get; set; }
        public bool IsCourseEditor { get; set; }
        public bool IsLector { get; set; }
        public bool IsStudent { get; set; }
    }
}
