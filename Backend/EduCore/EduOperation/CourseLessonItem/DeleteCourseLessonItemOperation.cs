using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLessonItem
{
    public class DeleteCourseLessonItemOperation : BaseOperation
    {
        public DeleteCourseLessonItemOperation() : base("DELETE_COURSE_LESSON_ITEM")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}