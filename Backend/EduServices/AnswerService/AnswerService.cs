using EduRepository.AnswerRepository;
using Model.Functions.Answer;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.AnswerService
{
    public class AnswerService : BaseService, IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }
        public void AddAnswer(AddAnswer addAnswer)
        {
            _answerRepository.AddAnswer(addAnswer);
        }

        public void DeleteAnswer(Guid answerId)
        {
            _answerRepository.DeleteEntity<TestQuestionAnswer>(answerId);
        }

        public IEnumerable<GetAnswersInQuestion> GetAnswersInQuestion(Guid questionId)
        {
            return _answerRepository.GetAnswersInQuestion(questionId);
        }

        public GetAnswerDetail GetAnswerDetail(Guid answerId)
        {
            return _answerRepository.GetAnswerDetail(answerId);
        }

        public void UpdateAnswer(UpdateAnswer updateAnswer)
        {
            _answerRepository.UpdateAnswer(updateAnswer);
        }
    }
}
