using System;

namespace Model.Functions.Answer
{
    public class GetAnswerDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
    }
}
