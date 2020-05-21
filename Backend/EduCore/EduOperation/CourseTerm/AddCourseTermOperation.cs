using EduCore.DataTypes;

namespace EduCore.EduOperation
{
    public class AddCourseTermOperation : BaseOperation
    {
        public AddCourseTermOperation() : base("ADD_COURSE_TERM")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}