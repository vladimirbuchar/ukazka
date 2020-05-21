using Model.Functions.Shared;
using System;
using System.Collections.Generic;

namespace Model.Functions.User
{
    public class UpdateUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; }
        public HashSet<FAddress> Addresses;
    }
}
