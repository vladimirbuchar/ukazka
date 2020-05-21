using System;
using WebModel.Shared;

namespace WebModel.QuestionDto
{
    public class GetQuestionsInBankDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public Guid AnswerMode { get; set; }
    }
}
