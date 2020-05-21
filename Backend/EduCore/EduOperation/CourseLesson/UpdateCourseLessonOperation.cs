using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLesson
{
    public class UpdateCourseLessonOperation : BaseOperation
    {
        public UpdateCourseLessonOperation() : base("UPDATE_COURSE_LESSON")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}