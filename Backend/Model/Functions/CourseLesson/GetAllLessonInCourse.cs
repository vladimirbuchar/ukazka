using System;

namespace Model.Functions.CourseLesson
{
    public class GetAllLessonInCourse : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Position { get; set; } = 0;
    }
}
