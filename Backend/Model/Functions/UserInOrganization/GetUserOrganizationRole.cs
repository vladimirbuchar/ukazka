using Model.Tables.Edu;
using System;

namespace Model.Functions.UserInOrganization
{
    public class GetUserOrganizationRole : SqlFunction
    {
        public Guid Id { get; set; }
        public string SystemIdentificator { get; set; }
        public bool IsOrganizationOwner()
        {
            return SystemIdentificator == OrganizationRoleValue.ORGANIZATION_OWNER;
        }
        public bool IsOrganizationAdministrator()
        {
            return SystemIdentificator == OrganizationRoleValue.ORGANIZATION_ADMINISTATOR;
        }
        public bool IsCourseAdministrator()
        {
            return SystemIdentificator == OrganizationRoleValue.COURSE_ADMINISTATOR;
        }
        public bool IsCourseEditor()
        {
            return SystemIdentificator == OrganizationRoleValue.COURSE_EDITOR;
        }
        public bool IsLector()
        {
            return SystemIdentificator == OrganizationRoleValue.LECTOR;
        }
        public bool IsStudent()
        {
            return SystemIdentificator == OrganizationRoleValue.STUDENT;
        }
    }
}
