using System;

namespace Model.Functions.CourseLessonItem
{
    public class GetCourseLessonItems : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
