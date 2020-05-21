using System;
using WebModel.Shared;

namespace WebModel.AnswerDto
{
    public class UpdateAnswerDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
        public Guid Id { get; set; }
        public string UserAccessToken { get; set; }
    }
}
