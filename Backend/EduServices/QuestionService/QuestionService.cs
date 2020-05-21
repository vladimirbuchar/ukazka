using EduRepository.QuestionRepository;
using Model.Functions.Question;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.QuestionService
{
    public class QuestionService : BaseService, IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public void AddQuestion(AddQuestion addQuestion)
        {
            _questionRepository.AddQuestion(addQuestion);
        }

        public void DeleteQuestion(Guid questionId)
        {
            _questionRepository.DeleteEntity<TestQuestion>(questionId);
        }

        public void UpdateQuestion(UpdateQuestion updateQuestion)
        {
            _questionRepository.UpdateQuestion(updateQuestion);
        }


        public GetQuestionDetail GetQuestionDetail(Guid questionId)
        {
            return _questionRepository.GetQuestionDetail(questionId);
        }

        public IEnumerable<GetQuestionsInBank> GetQuestionsInBank(Guid bankOfQuestionId)
        {
            return _questionRepository.GetQuestionsInBank(bankOfQuestionId);

        }
    }
}
