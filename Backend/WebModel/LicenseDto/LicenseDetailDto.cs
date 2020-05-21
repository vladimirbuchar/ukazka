using System;
using WebModel.Shared;

namespace WebModel.LicenseDto
{
    public class LicenseDetailDto : BaseDto
    {
        public Guid Id { get; set; }
        public string LicenseName { get; set; }
        public string Identificator { get; set; }
        public int MaximumStudents { get; set; }
        public int MaximumBranch { get; set; }
        public int MaximumLectors { get; set; }
        public int MaximumCourse { get; set; }
        public double MounthPrice { get; set; }
        public double OneYearSale { get; set; }
        public double OneYearPrice { get; set; }
        public bool Support { get; set; }
        public bool SendCourseInquiry { get; set; }
        public bool CreatePrivateCourse { get; set; }
        public int Priority { get; set; }
    }
}
