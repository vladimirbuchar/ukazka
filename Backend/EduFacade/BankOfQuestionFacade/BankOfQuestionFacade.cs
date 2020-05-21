using Core.DataTypes;
using EduFacade.BankOfQuestionFacade.Convertor;
using EduServices.CourseService;
using Model.Functions.BankOfQuestion;
using System;
using System.Collections.Generic;
using WebModel.BankOfQuestionDto;

namespace EduFacade.BankOfQuestionFacade
{
    public class BankOfQuestionFacade : BaseFacade, IBankOfQuestionFacade
    {
        private readonly IBankOfQuestionService _bankOfQuestionService;
        private readonly IBankOfQuestionConvertor _bankOfQuestionConvertor;
        public BankOfQuestionFacade(IBankOfQuestionService bankOfQuestionService, IBankOfQuestionConvertor bankOfQuestionConvertor)
        {
            _bankOfQuestionService = bankOfQuestionService;
            _bankOfQuestionConvertor = bankOfQuestionConvertor;
        }

        public Result AddBankOfQuestion(AddBankOfQuestionDto addBankOfQuestionDto)
        {
            AddBankOfQuestion addBankOfQuestion = _bankOfQuestionConvertor.ConvertToBussinessEntity(addBankOfQuestionDto);
            _bankOfQuestionService.AddBankOfQuestion(addBankOfQuestion);
            return new Result();
        }

        public List<GetBankOfQuestionInOrganizationDto> GetBankOfQuestionInOrganization(Guid organizationId)
        {
            return _bankOfQuestionConvertor.ConvertToWebModel(_bankOfQuestionService.GetBankOfQuestionInOrganization(organizationId));
        }

        public GetBankOfQuestionDetailDto GetBankOfQuestionDetail(Guid bankOfQuestionId)
        {
            return _bankOfQuestionConvertor.ConvertToWebModel(_bankOfQuestionService.GetBankOfQuestionDetail(bankOfQuestionId));
        }

        public Result UpdateBankOfQuestion(UpdateBankOfQuestionDto updateBankOfQuestionDto)
        {
            UpdateBankOfQuestion updateBankOfQuestion = _bankOfQuestionConvertor.ConvertToBussinessEntity(updateBankOfQuestionDto);
            _bankOfQuestionService.UpdateBankOfQuestion(updateBankOfQuestion);
            return new Result();
        }

        public void DeleteBankOfQuestion(Guid bankOfQuestionId)
        {
            _bankOfQuestionService.DeleteBankOfQuestion(bankOfQuestionId);
        }
    }
}
