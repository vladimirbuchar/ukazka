using System;
using WebModel.Shared;

namespace WebModel.LicenseDto
{
    public class LicenseListItemDto : BaseDto
    {
        public Guid Id { get; internal set; }
        public string LicenseName { get; internal set; }
        public string Identificator { get; internal set; }
        public int MaximumStudents { get; internal set; }
        public int MaximumBranch { get; internal set; }
        public int MaximumLectors { get; internal set; }
        public int MaximumCourse { get; internal set; }
        public double MounthPrice { get; internal set; }
        public double OneYearSale { get; internal set; }
        public double OneYearPrice { get; internal set; }
        public bool Support { get; internal set; }
        public bool SendCourseInquiry { get; internal set; }
        public bool CreatePrivateCourse { get; internal set; }
        public int Priority { get; internal set; }
    }
}