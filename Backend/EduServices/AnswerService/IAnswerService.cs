using Model.Functions.Answer;
using System;
using System.Collections.Generic;

namespace EduServices.AnswerService
{
    public interface IAnswerService : IBaseService
    {
        /// <summary>
        /// create new answer in question
        /// </summary>
        /// <param name="request"></param>
        void AddAnswer(AddAnswer addAnswer);
        /// <summary>
        /// change exist answer
        /// </summary>
        /// <param name="request"></param>
        void UpdateAnswer(UpdateAnswer updateAnswer);
        /// <summary>
        /// delete answer
        /// </summary>
        /// <param name="id"></param>
        void DeleteAnswer(Guid answerId);
        /// <summary>
        /// return answer detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GetAnswerDetail GetAnswerDetail(Guid answerId);
        /// <summary>
        /// return list with all answer to question
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        IEnumerable<GetAnswersInQuestion> GetAnswersInQuestion(Guid questionId);

    }
}
