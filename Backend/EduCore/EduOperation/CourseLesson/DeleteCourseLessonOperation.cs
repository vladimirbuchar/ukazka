using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLesson
{
    public class DeleteCourseLessonOperation : BaseOperation
    {
        public DeleteCourseLessonOperation() : base("DELETE_COURSE_LESSON")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}