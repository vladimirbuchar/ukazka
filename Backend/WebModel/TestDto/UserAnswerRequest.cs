using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.TestDto
{
    public class UserAnswerRequest : BaseDto
    {
        public Guid QuestionId { get; set; }
        public List<Guid> UserAnswers { get; set; }

    }
}
