using EduCore.DataTypes;

namespace EduCore.EduOperation.UserInOrganization
{
    public class GetAllUserInOrganizationOperation : BaseOperation
    {
        public GetAllUserInOrganizationOperation() : base("GET_ALL_USER_IN_ORGANIZATION")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}