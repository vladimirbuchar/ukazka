using System;
using WebModel.Shared;

namespace WebModel.BranchDto
{
    public class AddBranchDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public AddressDto Address { get; set; }
        public ContactInformationDto ContactInformation { get; set; }
        public bool IsMainBranch { get; set; } = false;
        public Guid OrganizationId { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
