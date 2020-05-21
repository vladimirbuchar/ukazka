using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseTerm
{
    public class DeleteCourseTermOperation : BaseOperation
    {
        public DeleteCourseTermOperation() : base("DELETE_COURSE_TERM")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}