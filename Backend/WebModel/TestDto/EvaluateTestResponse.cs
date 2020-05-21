using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.TestDto
{
    public class EvaluateTestResponse : BaseDto
    {
        public bool TestCompleted { get; set; }
        public List<EvaluateQuestion> Questions { get; set; }

    }
}
