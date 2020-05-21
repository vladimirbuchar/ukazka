using Model.Functions.Question;
using System.Collections.Generic;
using WebModel.QuestionDto;

namespace EduFacade.QuestionFacade.Convertor
{
    public class QuestionConvertor : IQuestionConvertor
    {
        public AddQuestion ConvertToBussinessEntity(AddQuestionDto addQuestionDto)
        {
            return new AddQuestion()
            {
                AnswerModeId = addQuestionDto.AnswerModeId,
                BankOfQUestionId = addQuestionDto.BankOfQUestionId,
                Question = addQuestionDto.Question
            };
        }

        public UpdateQuestion ConvertToBussinessEntity(UpdateQuestionDto updateQuestionDto)
        {
            return new UpdateQuestion()
            {
                AnswerModeId = updateQuestionDto.AnswerModeId,
                Id = updateQuestionDto.Id,
                Question = updateQuestionDto.Question
            };
        }

        public List<GetQuestionsInBankDto> ConvertToWebModel(IEnumerable<GetQuestionsInBank> getQuestionsInBanks)
        {
            List<GetQuestionsInBankDto> data = new List<GetQuestionsInBankDto>();
            foreach (GetQuestionsInBank item in getQuestionsInBanks)
            {
                data.Add(new GetQuestionsInBankDto()
                {
                    AnswerMode = item.AnswerModeId,
                    Id = item.Id,
                    Question = item.Question
                });
            }
            return data;
        }

        public GetQuestionDetailDto ConvertToWebModel(GetQuestionDetail getQuestionDetail)
        {
            return new GetQuestionDetailDto()
            {
                AnswerModeId = getQuestionDetail.AnswerModeId,
                Id = getQuestionDetail.Id,
                Question = getQuestionDetail.Question
            };
        }
    }
}
