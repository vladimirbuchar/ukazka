using System;
using WebModel.Shared;

namespace WebModel.CourseLesson
{
    public class AddCourseLessonDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CourseId { get; set; }
        public string UserAccessToken { get; set; }
    }
}
