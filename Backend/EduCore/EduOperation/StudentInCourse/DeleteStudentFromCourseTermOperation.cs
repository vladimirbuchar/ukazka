using EduCore.DataTypes;

namespace EduCore.EduOperation.StudentInCourse
{
    public class DeleteStudentFromCourseTermOperation : BaseOperation
    {
        public DeleteStudentFromCourseTermOperation() : base("DELETE_STUDENT_FROM_COURSE_TERM")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}