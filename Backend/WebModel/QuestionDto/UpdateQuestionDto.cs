using System;
using WebModel.Shared;

namespace WebModel.QuestionDto
{
    public class UpdateQuestionDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public Guid AnswerModeId { get; set; }
        public string UserAccessToken { get; set; }
    }
}
