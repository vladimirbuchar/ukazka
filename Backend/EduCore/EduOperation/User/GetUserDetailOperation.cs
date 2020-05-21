using EduCore.DataTypes;

namespace EduCore.EduOperation.User
{
    public class GetUserDetailOperation : BaseOperation
    {
        public GetUserDetailOperation() : base("GET_USER_DETAIL")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
            Lector = true;
            Student = true;
        }
    }
}