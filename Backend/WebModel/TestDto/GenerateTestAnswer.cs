using System;
using WebModel.Shared;

namespace WebModel.TestDto
{
    public class GenerateTestAnswer : BaseDto
    {
        public Guid AnswerId { get; set; }
        public string Answer { get; set; }
    }
}
