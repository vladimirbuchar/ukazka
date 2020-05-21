using System;

namespace Model.Functions.Organization
{
    public class GetOrganizationAddress : SqlFunction
    {
        public Guid CountryId { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public Guid AddressTypeId { get; set; }
        public string AddressTypeIdentificator { get; set; }
    }
}
