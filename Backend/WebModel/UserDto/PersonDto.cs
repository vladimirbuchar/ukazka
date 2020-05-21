using Core.Extension;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.UserDto
{
    public class PersonDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string FullName =>
            FirstName.IsNullOrEmptyWithTrim() && SecondName.IsNullOrEmptyWithTrim() && LastName.IsNullOrEmptyWithTrim() ? string.Empty :
            SecondName.IsNullOrEmptyWithTrim() ?
            string.Format("{0} {1}", FirstName.Trim(), LastName.Trim()) :
            string.Format("{0} {1} {2}", FirstName.Trim(), SecondName.Trim(), LastName.Trim());
        public List<AddressDto> Address { get; set; } = new List<AddressDto>();

    }
}
