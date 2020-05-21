using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.OrganizationDto
{
    public class GetOrganizationDetailDto : BaseDto, IBasicInformationDto
    {
        public Guid Id { get; set; }
        public Guid LicenseId { get; set; }
        public bool CanSendCourseInquiry { get; set; }
        public ContactInformationDto ContactInformation { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HashSet<AddressDto> Addresses { get; set; }
    }
}