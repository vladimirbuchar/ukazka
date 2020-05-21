using System;
using WebModel.Shared;

namespace WebModel.QuestionDto
{
    public class GetQuestionDetailDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public Guid AnswerModeId { get; set; }
    }
}
