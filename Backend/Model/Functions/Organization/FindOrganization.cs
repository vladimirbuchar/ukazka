using System;

namespace Model.Functions.Organization
{
    public class FindOrganization : SqlFunction
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
