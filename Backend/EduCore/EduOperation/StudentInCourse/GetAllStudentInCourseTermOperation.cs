using EduCore.DataTypes;

namespace EduCore.EduOperation.StudentInCourse
{
    public class GetAllStudentInCourseTermOperation : BaseOperation
    {
        public GetAllStudentInCourseTermOperation() : base("GET_ALL_STUDENT_IN_COURSE_TERM")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}