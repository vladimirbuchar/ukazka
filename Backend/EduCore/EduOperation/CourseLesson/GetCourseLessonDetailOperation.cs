using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLesson
{
    public class GetCourseLessonDetailOperation : BaseOperation
    {
        public GetCourseLessonDetailOperation() : base("GET_COURSE_LESSON_DETAIL")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}