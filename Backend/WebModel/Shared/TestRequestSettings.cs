using EduCore.DataTypes;
using System;

namespace WebModel.Shared
{
    public class TestRequestSettings : IBaseDtoWithUserAccessToken
    {
        public bool TestRequest { get; set; }
        public BaseDto Request { get; set; }
        public bool ValidateAccessToken { get; set; }
        public string AccessToken { get; set; }
        public Guid OrganizationId { get; set; }
        public OperationType OperationType { get; set; }
        public bool ValidateLicense { get; set; }
        public bool ValidateByUserId { get; set; }
        public Guid UserId { get; set; }
        public bool ValidateByUserEmail { get; set; }
        public string UserEmail { get; set; }
        public string UserAccessToken { get; set; }
    }
}
