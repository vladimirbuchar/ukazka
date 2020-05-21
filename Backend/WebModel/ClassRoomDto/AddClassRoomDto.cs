using System;
using WebModel.Shared;

namespace WebModel.ClassRoomDto
{
    public class AddClassRoomDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public int Floor { get; set; }
        public int MaxCapacity { get; set; }
        public Guid BranchId { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
