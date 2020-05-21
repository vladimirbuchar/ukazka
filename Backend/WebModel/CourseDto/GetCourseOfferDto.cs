using System;
using WebModel.Shared;

namespace WebModel.CourseDto
{
    public class GetCourseOfferDto : BaseDto
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public CoursePriceDto Price { get; set; }
        public string CourseImage { get; set; }
        public int DefaultMinimumStudents { get; set; }
        public int DefaultMaximumStudents { get; set; }
        public string CourseType { get; set; }
        public string Organization { get; set; }
        public AddressDto Address { get; set; }
        public int FreePlaces { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public string LectorName { get; set; }
        public Guid LectorId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid BranchId { get; set; }
        public Guid TermId { get; set; }
        public string Time { get; set; }
    }
}
