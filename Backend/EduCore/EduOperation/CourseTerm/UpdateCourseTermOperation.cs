using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseTerm
{
    public class UpdateCourseTermOperation : BaseOperation
    {
        public UpdateCourseTermOperation() : base("UPDATE_COURSE_TERM")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}