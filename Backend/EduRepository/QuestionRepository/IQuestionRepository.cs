using Model.Functions.Question;
using System;
using System.Collections.Generic;

namespace EduRepository.QuestionRepository
{
    public interface IQuestionRepository : IBaseRepository
    {
        IEnumerable<GetQuestionsInBank> GetQuestionsInBank(Guid questionBankId);
        void AddQuestion(AddQuestion addQuestion);
        GetQuestionDetail GetQuestionDetail(Guid questionId);
        void UpdateQuestion(UpdateQuestion updateQuestion);
    }
}
