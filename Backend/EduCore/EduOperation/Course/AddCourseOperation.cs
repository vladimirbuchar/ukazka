using EduCore.DataTypes;

namespace EduCore.EduOperation.Course
{
    public class AddCourseOperation : BaseOperation
    {
        public AddCourseOperation() : base("ADD_COURSE")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}