using System;
using WebModel.Shared;

namespace WebModel.CourseDto
{
    public class UpdateCourseDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public CoursePriceDto Price { get; set; }
        public string CourseImage { get; set; }
        public int DefaultMinimumStudents { get; set; }
        public int DefaultMaximumStudents { get; set; }
        public Guid CourseTypeId { get; set; }
        public Guid CourseStatusId { get; set; }
        public Guid OrganizationId { get; set; }
        public bool IsPrivateCourse { get; set; } = false;
        public Guid Id { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
