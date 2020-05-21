using System;

namespace Model.Functions.CourseLesson
{
    public class GetCourseLessonDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
