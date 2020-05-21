using System;

namespace Model.Functions.UserInOrganization
{
    public class GetAllUserInOrganization : SqlFunction
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
    }
}
