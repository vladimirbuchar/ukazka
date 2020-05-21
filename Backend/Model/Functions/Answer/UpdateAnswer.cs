using System;

namespace Model.Functions.Answer
{
    public class UpdateAnswer
    {
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
        public Guid AnswerId { get; set; }
    }
}
