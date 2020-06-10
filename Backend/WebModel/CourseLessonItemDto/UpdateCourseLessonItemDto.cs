using System;
using WebModel.Shared;

namespace WebModel.CourseLessonItemDto
{
    public class UpdateCourseLessonItemDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public Guid CourseLessonItemId { get; set; }
        public string Html { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TemplateId { get; set; }
    }
}
