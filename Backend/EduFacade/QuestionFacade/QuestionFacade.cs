using Core.DataTypes;
using EduFacade.QuestionFacade.Convertor;
using EduServices.QuestionService;
using Model.Functions.Question;
using System;
using System.Collections.Generic;
using WebModel.QuestionDto;

namespace EduFacade.CourseFacade
{
    public class QuestionFacade : BaseFacade, IQuestionFacade
    {
        private readonly IQuestionService _questionService;
        private readonly IQuestionConvertor _questionConvertor;
        public QuestionFacade(IQuestionService questionService, IQuestionConvertor questionConvertor)
        {
            _questionService = questionService;
            _questionConvertor = questionConvertor;
        }

        public Result AddQuestion(AddQuestionDto addQuestionDto)
        {
            AddQuestion addQuestion = _questionConvertor.ConvertToBussinessEntity(addQuestionDto);
            _questionService.AddQuestion(addQuestion);
            return new Result();
        }

        public List<GetQuestionsInBankDto> GetQuestionsInBank(Guid bankOfQuestionId)
        {
            return _questionConvertor.ConvertToWebModel(_questionService.GetQuestionsInBank(bankOfQuestionId));
        }

        public GetQuestionDetailDto GetQuestionDetail(Guid qestionId)
        {
            return _questionConvertor.ConvertToWebModel(_questionService.GetQuestionDetail(qestionId));
        }

        public Result UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            UpdateQuestion updateQuestion = _questionConvertor.ConvertToBussinessEntity(updateQuestionDto);
            _questionService.UpdateQuestion(updateQuestion);
            return new Result();
        }

        public void DeleteQuestion(Guid questionId)
        {
            _questionService.DeleteQuestion(questionId);
        }
    }
}
