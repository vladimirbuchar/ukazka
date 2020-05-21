using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLesson
{
    public class GetAllLessonInCourseOperation : BaseOperation
    {
        public GetAllLessonInCourseOperation() : base("GET_ALL_LESSON_IN_COURSE")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}