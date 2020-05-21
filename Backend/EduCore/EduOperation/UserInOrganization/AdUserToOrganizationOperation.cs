using EduCore.DataTypes;

namespace EduCore.EduOperation.UserInOrganization
{
    public class AdUserToOrganizationOperation : BaseOperation
    {
        public AdUserToOrganizationOperation() : base("ADD_USER_TO_ORGANIZATION")
        {
            OrganizationAdministrator = true;
        }
    }
}