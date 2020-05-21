using System;

namespace Model.Functions.Branch
{
    public class GetBranchDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public bool IsMainBranch { get; set; }
        public Guid CountryId { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WWW { get; set; }

    }
}
