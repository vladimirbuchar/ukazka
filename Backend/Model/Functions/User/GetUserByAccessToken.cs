using System;

namespace Model.Functions.User
{
    public class GetUserByAccessToken : SqlFunction
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
    }
}
