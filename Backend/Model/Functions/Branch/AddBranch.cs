using System;

namespace Model.Functions.Branch
{
    public class AddBranch
    {
        public bool IsMainBranch { get; set; }
        public Guid OrganizationId { get; set; }
        public string ContactInformationEmail { get; set; }
        public string ContactInformationPhoneNumber { get; set; }
        public string ContactInformationWWW { get; set; }
        public string BasicInformationName { get; set; }
        public string BasicInformationDescription { get; set; }
        public Guid AddressCountryId { get; set; }
        public string AddressRegion { get; set; }
        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public string AddressHouseNumber { get; set; }
        public string AddressZipCode { get; set; }

    }
}
