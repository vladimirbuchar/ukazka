using System;

namespace Model.Functions.CourseStudent
{
    public class GetAllStudentInCourseTerm : SqlFunction
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Guid StudentId { get; set; }
    }
}
