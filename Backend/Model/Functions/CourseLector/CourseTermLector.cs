using System;

namespace Model.Functions.CourseLector
{
    public class CourseTermLector : SqlFunction
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Guid LectorId { get; set; }
    }
}
