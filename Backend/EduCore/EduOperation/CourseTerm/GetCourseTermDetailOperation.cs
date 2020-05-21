using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseTerm
{
    public class GetCourseTermDetailOperation : BaseOperation
    {
        public GetCourseTermDetailOperation() : base("GET_COURSE_TERM_DETAIL")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseAdministrator = true;
        }
    }
}