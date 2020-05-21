using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLessonItem
{
    public class UpdateCourseLessonItemOperation : BaseOperation
    {
        public UpdateCourseLessonItemOperation() : base("UPDATE_COURSE_LESSON_ITEM")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}