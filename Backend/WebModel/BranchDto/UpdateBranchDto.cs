using System;
using WebModel.Shared;

namespace WebModel.BranchDto
{
    public class UpdateBranchDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public Guid Id { get; set; }
        public AddressDto Address { get; set; }
        public ContactInformationDto ContactInformation { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMainBranch { get; set; } = false;
        public string UserAccessToken { get; set; }
    }
}
