using Model.Tables.Edu;
using System;

namespace Model.Functions.Organization
{
    public class GetMyOrganizations : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OrganizationRole { get; set; }
        public Guid UserInOrganizationRoleId { get; set; }
        public bool IsOrganizationOwner => OrganizationRole == OrganizationRoleValue.ORGANIZATION_OWNER;
        public bool IsOrganizationAdministrator => OrganizationRole == OrganizationRoleValue.ORGANIZATION_ADMINISTATOR;
        public bool IsCourseAdministrator => OrganizationRole == OrganizationRoleValue.COURSE_ADMINISTATOR;
        public bool IsCourseEditor => OrganizationRole == OrganizationRoleValue.COURSE_EDITOR;
        public bool IsLector => OrganizationRole == OrganizationRoleValue.LECTOR;
        public bool IsStudent => OrganizationRole == OrganizationRoleValue.STUDENT;


    }
}
