using System;

namespace Model.Functions.Answer
{
    public class AddAnswer
    {
        public Guid QuestionId { get; set; }
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
    }
}
