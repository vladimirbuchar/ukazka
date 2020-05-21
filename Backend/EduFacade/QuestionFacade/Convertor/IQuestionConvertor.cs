using Model.Functions.Question;
using System.Collections.Generic;
using WebModel.QuestionDto;

namespace EduFacade.QuestionFacade.Convertor
{
    public interface IQuestionConvertor
    {
        AddQuestion ConvertToBussinessEntity(AddQuestionDto addQuestionDto);
        List<GetQuestionsInBankDto> ConvertToWebModel(IEnumerable<GetQuestionsInBank> getQuestionsInBanks);
        GetQuestionDetailDto ConvertToWebModel(GetQuestionDetail getQuestionDetail);
        UpdateQuestion ConvertToBussinessEntity(UpdateQuestionDto updateQuestionDto);
    }
}
