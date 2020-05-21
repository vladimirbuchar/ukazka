using System;

namespace Model.Functions.Organization
{
    public class GetOrganizationDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public Guid LicenseId { get; set; }
        public bool CanSendCourseInquiry { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WWW { get; set; }
    }
}
