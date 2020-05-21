using Model.Functions.Shared;
using System;
using System.Collections.Generic;

namespace Model.Functions.Organization
{
    public class UpdateOrganization
    {
        public Guid OrganizationId { get; set; }
        public bool CanSendCourseInquiry { get; set; }
        public string ContactInformationEmail { get; set; }
        public string ContactInformationPhoneNumber { get; set; }
        public string ContactInformationWWW { get; set; }
        public string BasicInformationName { get; set; }
        public string BasicInformationDescription { get; set; }
        public HashSet<FAddress> Addresses { get; set; }

    }
}
