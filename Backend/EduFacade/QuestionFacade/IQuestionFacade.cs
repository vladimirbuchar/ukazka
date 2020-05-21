using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.QuestionDto;

namespace EduFacade.CourseFacade
{
    public interface IQuestionFacade : IBaseFacade
    {
        Result AddQuestion(AddQuestionDto addQuestionDto);
        List<GetQuestionsInBankDto> GetQuestionsInBank(Guid questionBankId);
        GetQuestionDetailDto GetQuestionDetail(Guid qestionId);
        Result UpdateQuestion(UpdateQuestionDto updateQuestionDto);
        void DeleteQuestion(Guid qestionId);
    }
}
