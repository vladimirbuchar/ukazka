using System;
using WebModel.Shared;

namespace WebModel.BankOfQuestionDto
{
    public class GetBankOfQuestionInOrganizationDto : IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
