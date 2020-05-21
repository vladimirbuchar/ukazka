using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.TestDto
{
    public class GenerateTestQuestion : BaseDto
    {
        public Guid QuestionId { get; set; }
        public string Question { get; set; }
        public List<GenerateTestAnswer> Answers { get; set; }
    }
}
