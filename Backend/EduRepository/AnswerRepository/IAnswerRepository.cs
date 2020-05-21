using Model.Functions.Answer;
using System;
using System.Collections.Generic;

namespace EduRepository.AnswerRepository
{
    public interface IAnswerRepository : IBaseRepository
    {
        IEnumerable<GetAnswersInQuestion> GetAnswersInQuestion(Guid questionId);
        void AddAnswer(AddAnswer addAnswer);
        GetAnswerDetail GetAnswerDetail(Guid answerId);
        void UpdateAnswer(UpdateAnswer updateAnswer);

    }
}
