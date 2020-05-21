using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLessonItem
{
    public class GetCourseLessonItemDetailOperation : BaseOperation
    {
        public GetCourseLessonItemDetailOperation() : base("GET_COURSE_LESSON_ITEM_DETAIL")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}