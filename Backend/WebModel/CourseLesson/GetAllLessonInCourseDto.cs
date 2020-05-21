using System;
using WebModel.Shared;

namespace WebModel.CourseLesson
{
    public class GetAllLessonInCourseDto : IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
