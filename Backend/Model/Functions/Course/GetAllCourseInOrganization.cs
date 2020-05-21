using System;

namespace Model.Functions.Course
{
    public class GetAllCourseInOrganization : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
