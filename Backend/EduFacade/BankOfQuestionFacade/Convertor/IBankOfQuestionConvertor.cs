using Model.Functions.BankOfQuestion;
using System.Collections.Generic;
using WebModel.BankOfQuestionDto;

namespace EduFacade.BankOfQuestionFacade.Convertor
{
    public interface IBankOfQuestionConvertor
    {
        AddBankOfQuestion ConvertToBussinessEntity(AddBankOfQuestionDto addBankOfQuestionDto);
        List<GetBankOfQuestionInOrganizationDto> ConvertToWebModel(List<GetBankOfQuestionInOrganization> getBankOfQuestionInOrganizations);
        GetBankOfQuestionDetailDto ConvertToWebModel(GetBankOfQuestionDetail getBankOfQuestionDetail);
        UpdateBankOfQuestion ConvertToBussinessEntity(UpdateBankOfQuestionDto updateBankOfQuestionDto);

    }
}
