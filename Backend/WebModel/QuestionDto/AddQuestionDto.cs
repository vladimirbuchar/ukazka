using System;
using WebModel.Shared;

namespace WebModel.QuestionDto
{
    public class AddQuestionDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public string Question { get; set; }
        public Guid AnswerModeId { get; set; }
        public Guid BankOfQUestionId { get; set; }
        public string UserAccessToken { get; set; }
    }
}
