using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseTerm
{
    public class GetAllTermInCourseOperation : BaseOperation
    {
        public GetAllTermInCourseOperation() : base("GET_ALL_TERM_IN_COURSE")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}