using EduCore.DataTypes;

namespace EduCore.EduOperation.StudentInCourse
{
    public class AddStudentToCourseOperation : BaseOperation
    {
        public AddStudentToCourseOperation() : base("ADD_STUDENT_TO_COURSE")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}