using EduCore.DataTypes;

namespace EduCore.EduOperation.UserInOrganization
{
    public class UpdateUserToOrganizationOperation : BaseOperation
    {
        public UpdateUserToOrganizationOperation() : base("UPDATE_USER_TO_ORGANIZATION")
        {
            OrganizationAdministrator = true;
        }
    }
}