using System;
using WebModel.Shared;

namespace WebModel.CourseDto
{
    public class CourseFilterDto : BaseDto
    {
        public CourseFilterDto()
        {
            Address = new AddressDto();
        }
        public Guid CategoryId { get; set; }
        public Guid OrganizationId { get; set; }
        public AddressDto Address { get; set; }
        public Guid BranchId { get; set; }
        public int MaxPrice { get; set; } = 0;
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public Guid CourseId { get; set; }
        public Guid LectorId { get; set; }
        public Guid ClassRoomId { get; set; }
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 50;
    }
}
