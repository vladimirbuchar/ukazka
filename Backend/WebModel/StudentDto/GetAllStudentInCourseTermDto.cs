using System;

namespace WebModel.StudentDto
{
    public class GetAllStudentInCourseTermDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Guid StudentId { get; set; }
    }
}
