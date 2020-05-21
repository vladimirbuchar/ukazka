using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLessonItem
{
    public class GetCourseLessonItemsOperation : BaseOperation
    {
        public GetCourseLessonItemsOperation() : base("GET_COURSE_LESSON_ITEMS")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}