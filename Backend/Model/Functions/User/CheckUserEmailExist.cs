using System;

namespace Model.Functions.User
{
    public class CheckUserEmailExist : SqlFunction
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
    }
}
