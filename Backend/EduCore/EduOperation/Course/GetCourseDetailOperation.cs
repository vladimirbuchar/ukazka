using EduCore.DataTypes;

namespace EduCore.EduOperation.Course
{
    public class GetCourseDetailOperation : BaseOperation
    {
        public GetCourseDetailOperation() : base("GET_COURSE_DETAIL")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}
