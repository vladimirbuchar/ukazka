using EduCore.DataTypes;

namespace EduCore.EduOperation.Course
{
    public class DeleteCourseOperation : BaseOperation
    {
        public DeleteCourseOperation() : base("DELETE_COURSE")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}