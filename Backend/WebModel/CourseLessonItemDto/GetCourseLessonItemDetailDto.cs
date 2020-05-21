using System;
using WebModel.Shared;

namespace WebModel.CourseLessonItemDto
{
    public class GetCourseLessonItemDetailDto : IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string Html { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
