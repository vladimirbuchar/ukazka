using System;
using WebModel.Shared;

namespace WebModel.UserDto
{
    public class GetUserDetailDto : BaseDto
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public PersonDto Person { get; set; }
    }
}
