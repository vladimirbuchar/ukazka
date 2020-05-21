using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLector
{
    public class DeleteCourseTermLectorOperation : BaseOperation
    {
        public DeleteCourseTermLectorOperation() : base("DELETE_LECTOR_FROM_COURSE_TERM")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}