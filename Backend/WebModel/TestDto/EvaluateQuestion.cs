using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.TestDto
{
    public class EvaluateQuestion : BaseDto
    {
        public Guid QuestionId { get; set; }
        public bool IsOk { get; set; }
        public List<Guid> TrueAnswers { get; set; }

    }
}
