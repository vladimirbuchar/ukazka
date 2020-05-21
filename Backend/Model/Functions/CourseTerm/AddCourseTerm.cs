using System;

namespace Model.Functions.CourseTerm
{
    public class AddCourseTerm
    {
        public Guid CourseId { get; set; }
        public double CoursePrice { get; set; }
        public int CoursePriceSale { get; set; }
        public DateTime? ActiveFrom { get; set; }
        public DateTime? ActiveTo { get; set; }
        public DateTime? RegistrationFrom { get; set; }
        public DateTime? RegistrationTo { get; set; }
        public string BasicInformationName { get; set; }
        public string BasicInformationDescription { get; set; }
        public int StudentCountMinimumStudent { get; set; }
        public int StudentCountMaximumStudent { get; set; }
        public Guid ClassRoomId { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public Guid TimeFromId { get; set; }
        public Guid TimeToId { get; set; }
    }
}
