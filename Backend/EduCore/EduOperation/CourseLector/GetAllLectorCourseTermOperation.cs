using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLector
{
    public class GetAllLectorCourseTermOperation : BaseOperation
    {
        public GetAllLectorCourseTermOperation() : base("GET_ALL_LECTOR_COURSE")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
        }
    }
}