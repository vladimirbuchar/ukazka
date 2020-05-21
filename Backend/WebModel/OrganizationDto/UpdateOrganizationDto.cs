using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.OrganizationDto
{
    public class UpdateOrganizationDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public Guid Id { get; set; }
        public ContactInformationDto ContactInformation { get; set; }
        public HashSet<AddressDto> Addresses { get; set; }
        public bool CanSendCourseInquiry { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
