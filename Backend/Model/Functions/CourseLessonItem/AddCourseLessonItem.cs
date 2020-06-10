using System;

namespace Model.Functions.CourseLessonItem
{
    public class AddCourseLessonItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Html { get; set; }
        public Guid CourseLessonId { get; set; }
        public Guid TemplateId { get; set; }
    }
}
