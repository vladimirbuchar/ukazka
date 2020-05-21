using System;
using WebModel.Shared;

namespace WebModel.CourseDto
{
    public class AddCourseDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public CoursePriceDto Price { get; set; } = new CoursePriceDto();
        public string CourseImage { get; set; }
        public int DefaultMinimumStudents { get; set; } = 0;
        public int DefaultMaximumStudents { get; set; } = 0;
        public Guid CourseTypeId { get; set; }
        public Guid CourseStatusId { get; set; }
        public Guid OrganizationId { get; set; }
        public bool IsPrivateCourse { get; set; } = false;
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
