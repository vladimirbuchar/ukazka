using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.BankOfQuestionDto;

namespace EduFacade.BankOfQuestionFacade
{
    public interface IBankOfQuestionFacade : IBaseFacade
    {
        Result AddBankOfQuestion(AddBankOfQuestionDto addBankOfQuestionDto);
        List<GetBankOfQuestionInOrganizationDto> GetBankOfQuestionInOrganization(Guid organizationId);
        GetBankOfQuestionDetailDto GetBankOfQuestionDetail(Guid bankOfQuestionId);
        Result UpdateBankOfQuestion(UpdateBankOfQuestionDto updateBankOfQuestionDto);
        void DeleteBankOfQuestion(Guid bankOfQuestionId);
    }
}
