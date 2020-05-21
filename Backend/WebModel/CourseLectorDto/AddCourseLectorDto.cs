using System;
using WebModel.Shared;

namespace WebModel.CourseLectorDto
{
    public class AddCourseLectorDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public Guid CourseTerm { get; set; }
        public Guid CourseLector { get; set; }
        public string UserAccessToken { get; set; }
    }
}
