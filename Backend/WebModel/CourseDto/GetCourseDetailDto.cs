using System;
using WebModel.Shared;

namespace WebModel.CourseDto
{
    public class GetCourseDetailDto : BaseDto, IBasicInformationDto
    {
        public Guid Id { get; set; }
        public bool IsPrivateCourse { get; set; }
        public CoursePriceDto CoursePrice { get; set; }
        public Guid CourseStatusId { get; set; }
        public Guid CourseTypeId { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
