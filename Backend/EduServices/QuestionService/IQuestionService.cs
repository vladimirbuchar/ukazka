using Model.Functions.Question;
using System;
using System.Collections.Generic;

namespace EduServices.QuestionService
{
    public interface IQuestionService : IBaseService
    {
        void AddQuestion(AddQuestion addQuestion);
        void UpdateQuestion(UpdateQuestion updateQuestion);
        void DeleteQuestion(Guid questionOid);
        GetQuestionDetail GetQuestionDetail(Guid questionId);
        IEnumerable<GetQuestionsInBank> GetQuestionsInBank(Guid bankOfQuestionId);
    }
}
