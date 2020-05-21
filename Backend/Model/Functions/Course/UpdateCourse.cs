using System;

namespace Model.Functions.Course
{
    public class UpdateCourse
    {
        public Guid CourseTypeId { get; set; }
        public Guid CourseStatusId { get; set; }
        public bool IsPrivateCourse { get; set; }
        public Guid CourseId { get; set; }
        public string BasicInformationName { get; set; }
        public string BasicInformationDescription { get; set; }
        public double CoursePrice { get; set; }
        public int CoursePriceSale { get; set; }
        public int StudentCountMinimumStudent { get; set; }
        public int StudentCountMaximumStudent { get; set; }
    }
}
