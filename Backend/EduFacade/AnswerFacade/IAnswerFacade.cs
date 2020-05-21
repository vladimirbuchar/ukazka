using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.AnswerDto;

namespace EduFacade.AnswerFacade
{
    public interface IAnswerFacade : IBaseFacade
    {
        Result AddAnswer(AddAnswerDto addAnswerDto);
        List<GetAnswersInQuestionDto> GetAnswersInQuestion(Guid questionId);
        GetAnswerDetailDto GetAnswerDetail(Guid qestionId);
        Result UpdateAnswer(UpdateAnswerDto updateAnswerDto);
        void DeleteAnswer(Guid answerId);
    }
}
