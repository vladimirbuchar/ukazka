using System;

namespace WebModel.Shared
{
    public class AddressDto : BaseDto
    {
        public Guid CountryId { get; set; } = Guid.Empty;
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public Guid AddressTypeId { get; set; } = Guid.Empty;
        public string CountryName { get; set; } = string.Empty;
    }
}
