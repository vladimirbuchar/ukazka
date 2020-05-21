using Model.Functions.Answer;
using System.Collections.Generic;
using WebModel.AnswerDto;

namespace EduFacade.AnswerFacade.Convertor
{
    public class AnswerConvertor : IAnswerConvertor
    {
        public AddAnswer ConvertToBussinessEntity(AddAnswerDto addAnswerDto)
        {
            return new AddAnswer()
            {
                Answer = addAnswerDto.Answer,
                IsTrueAnswer = addAnswerDto.IsTrueAnswer,
                QuestionId = addAnswerDto.QuestionId
            };
        }

        public UpdateAnswer ConvertToBussinessEntity(UpdateAnswerDto updateAnswerDto)
        {
            return new UpdateAnswer()
            {
                Answer = updateAnswerDto.Answer,
                AnswerId = updateAnswerDto.Id,
                IsTrueAnswer = updateAnswerDto.IsTrueAnswer
            };
        }

        public List<GetAnswersInQuestionDto> ConvertToWebModel(IEnumerable<GetAnswersInQuestion> getAnswersInQuestions)
        {
            List<GetAnswersInQuestionDto> data = new List<GetAnswersInQuestionDto>();
            foreach (GetAnswersInQuestion item in getAnswersInQuestions)
            {
                data.Add(new GetAnswersInQuestionDto()
                {
                    Answer = item.Answer,
                    Id = item.Id,
                    IsTrueAnswer = item.IsTrueAnswer
                });
            }
            return data;
        }

        public GetAnswerDetailDto ConvertToWebModel(GetAnswerDetail answerDetail)
        {
            return new GetAnswerDetailDto()
            {
                Answer = answerDetail.Answer,
                Id = answerDetail.Id,
                IsTrueAnswer = answerDetail.IsTrueAnswer
            };
        }
    }
}
