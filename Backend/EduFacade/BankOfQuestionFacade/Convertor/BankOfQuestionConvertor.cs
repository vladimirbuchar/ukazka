using Model.Functions.BankOfQuestion;
using System.Collections.Generic;
using WebModel.BankOfQuestionDto;

namespace EduFacade.BankOfQuestionFacade.Convertor
{
    public class BankOfQuestionConvertor : IBankOfQuestionConvertor
    {
        public AddBankOfQuestion ConvertToBussinessEntity(AddBankOfQuestionDto addBankOfQuestionDto)
        {
            return new AddBankOfQuestion()
            {
                Description = addBankOfQuestionDto.Description,
                Name = addBankOfQuestionDto.Name,
                OrganizationId = addBankOfQuestionDto.OrganizationId
            };
        }

        public UpdateBankOfQuestion ConvertToBussinessEntity(UpdateBankOfQuestionDto updateBankOfQuestionDto)
        {
            return new UpdateBankOfQuestion()
            {
                BankOfQuestionId = updateBankOfQuestionDto.BankOfQuestionId,
                Description = updateBankOfQuestionDto.Description,
                Name = updateBankOfQuestionDto.Name
            };
        }

        public List<GetBankOfQuestionInOrganizationDto> ConvertToWebModel(List<GetBankOfQuestionInOrganization> getBankOfQuestionInOrganizations)
        {
            List<GetBankOfQuestionInOrganizationDto> data = new List<GetBankOfQuestionInOrganizationDto>();
            foreach (GetBankOfQuestionInOrganization item in getBankOfQuestionInOrganizations)
            {
                data.Add(new GetBankOfQuestionInOrganizationDto()
                {
                    Description = item.Description,
                    Name = item.Name,
                    Id = item.Id
                });
            }
            return data;
        }

        public GetBankOfQuestionDetailDto ConvertToWebModel(GetBankOfQuestionDetail getBankOfQuestionDetail)
        {
            return new GetBankOfQuestionDetailDto()
            {
                Description = getBankOfQuestionDetail.Description,
                Name = getBankOfQuestionDetail.Name,
                Id = getBankOfQuestionDetail.Id
            };
        }
    }
}
