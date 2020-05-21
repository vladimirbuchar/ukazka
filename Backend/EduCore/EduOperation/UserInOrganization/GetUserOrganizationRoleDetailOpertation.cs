using EduCore.DataTypes;

namespace EduCore.EduOperation.UserInOrganization
{
    public class GetUserOrganizationRoleDetailOpertation: BaseOperation
    {
        public GetUserOrganizationRoleDetailOpertation() : base("GET_USER_ROLE_FROM_ORGANIZATION")
        {
            OrganizationAdministrator = true;
        }
    }
}