using System;

namespace Model.Functions.CourseLessonItem
{
    public class GetCourseLessonItemDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Html { get; set; }
        public Guid CourseLessonItemTemplateId { get; set; }
        public string TemplateIdentificator { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public Guid FileId { get; set; }
    }
}
