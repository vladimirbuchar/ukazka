using System;

namespace Model.Functions.User
{
    public class GetUserDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Guid PersonId { get; set; }
    }
}
