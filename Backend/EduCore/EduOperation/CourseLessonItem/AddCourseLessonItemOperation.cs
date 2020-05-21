using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLessonItem
{
    public class AddCourseLessonItemOperation : BaseOperation
    {
        public AddCourseLessonItemOperation() : base("ADD_COURSE_LESSON_ITEM")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}