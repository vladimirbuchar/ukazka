using EduCore.DataTypes;

namespace EduCore.EduOperation.Course
{
    public class UpdateCourseOperation : BaseOperation
    {
        public UpdateCourseOperation() : base("UPDATE_COURSE")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}