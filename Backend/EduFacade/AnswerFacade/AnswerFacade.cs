using Core.DataTypes;
using EduFacade.AnswerFacade.Convertor;
using EduServices.AnswerService;
using Model.Functions.Answer;
using System;
using System.Collections.Generic;
using WebModel.AnswerDto;

namespace EduFacade.AnswerFacade
{
    public class AnswerFacade : BaseFacade, IAnswerFacade
    {
        private readonly IAnswerService _answerService;
        private readonly IAnswerConvertor _answerConvertor;
        public AnswerFacade(IAnswerService answerService, IAnswerConvertor answerConvertor)
        {
            _answerService = answerService;
            _answerConvertor = answerConvertor;
        }

        public Result AddAnswer(AddAnswerDto addAnswerDto)
        {
            AddAnswer addAnswer = _answerConvertor.ConvertToBussinessEntity(addAnswerDto);
            _answerService.AddAnswer(addAnswer);
            return new Result();
        }

        public List<GetAnswersInQuestionDto> GetAnswersInQuestion(Guid questionId)
        {
            return _answerConvertor.ConvertToWebModel(_answerService.GetAnswersInQuestion(questionId));
        }

        public GetAnswerDetailDto GetAnswerDetail(Guid answerId)
        {
            return _answerConvertor.ConvertToWebModel(_answerService.GetAnswerDetail(answerId));
        }

        public Result UpdateAnswer(UpdateAnswerDto updateAnswerDto)
        {
            UpdateAnswer updateAnswer = _answerConvertor.ConvertToBussinessEntity(updateAnswerDto);
            _answerService.UpdateAnswer(updateAnswer);
            return new Result();
        }

        public void DeleteAnswer(Guid answerId)
        {
            _answerService.DeleteAnswer(answerId);
        }
    }
}
