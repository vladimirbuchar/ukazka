using System;
using WebModel.Shared;

namespace WebModel.OrganizationDto
{
    public class GetOrganizationDetailWebDto : BaseDto, IBasicInformationDto
    {
        public Guid Id { get; set; }
        public ContactInformationDto ContactInformation { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}