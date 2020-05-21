using System;
using WebModel.Shared;

namespace WebModel.BankOfQuestionDto
{
    public class UpdateBankOfQuestionDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public Guid BankOfQuestionId { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
