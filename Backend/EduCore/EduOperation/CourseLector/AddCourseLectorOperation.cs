using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLector
{
    public class AddCourseLectorOperation : BaseOperation
    {
        public AddCourseLectorOperation() : base("ADD_COURSE_LECTOR")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}