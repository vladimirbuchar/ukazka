using System;
using WebModel.Shared;

namespace WebModel.UserDto
{
    public class UserListItemDto : BaseDto
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public PersonDto PersonName { get; set; }
    }
}
