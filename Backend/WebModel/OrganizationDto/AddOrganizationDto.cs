using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.OrganizationDto
{
    public class AddOrganizationDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public ContactInformationDto ContactInformation { get; set; }
        public HashSet<AddressDto> Addresses { get; set; }
        public bool CanSendCourseInquiry { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}