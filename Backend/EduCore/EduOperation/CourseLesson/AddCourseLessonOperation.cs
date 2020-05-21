using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLesson
{
    public class AddCourseLessonOperation : BaseOperation
    {
        public AddCourseLessonOperation() : base("ADD_COURSE_LESSON")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}