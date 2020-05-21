using System;

namespace Model.Functions.Question
{
    public class GetQuestionsInBank : SqlFunction
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public Guid AnswerModeId { get; set; }
    }
}
