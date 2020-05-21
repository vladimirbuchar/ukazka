using System;
using WebModel.Shared;

namespace WebModel.CourseLesson
{
    public class GetCourseLessonDetailDto : IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
