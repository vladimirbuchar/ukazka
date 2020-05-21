using System;
using WebModel.Shared;

namespace WebModel.CourseLesson
{
    public class UpdateCourseLessonDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
