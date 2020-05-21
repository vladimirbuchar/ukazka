using Model.Functions.Answer;
using System.Collections.Generic;
using WebModel.AnswerDto;

namespace EduFacade.AnswerFacade.Convertor
{
    public interface IAnswerConvertor
    {
        AddAnswer ConvertToBussinessEntity(AddAnswerDto addAnswerDto);
        List<GetAnswersInQuestionDto> ConvertToWebModel(IEnumerable<GetAnswersInQuestion> getAnswersInQuestions);
        GetAnswerDetailDto ConvertToWebModel(GetAnswerDetail answerDetail);
        UpdateAnswer ConvertToBussinessEntity(UpdateAnswerDto updateAnswerDto);
    }
}
