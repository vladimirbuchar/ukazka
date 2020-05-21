using System;
using WebModel.Shared;

namespace WebModel.OrganizationDto
{
    public class FindOrganizationDto : BaseDto
    {
        public Guid Id { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationDescription { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
}
