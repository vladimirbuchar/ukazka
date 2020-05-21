using System;
using WebModel.Shared;

namespace WebModel.AnswerDto
{
    public class AddAnswerDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public Guid QuestionId { get; set; }
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
        public string UserAccessToken { get; set; }
    }
}
