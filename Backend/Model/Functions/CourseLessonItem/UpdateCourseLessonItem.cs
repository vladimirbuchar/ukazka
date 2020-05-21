using System;

namespace Model.Functions.CourseLessonItem
{
    public class UpdateCourseLessonItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Html { get; set; }
        public Guid CourseLessonItemId { get; set; }
    }
}
