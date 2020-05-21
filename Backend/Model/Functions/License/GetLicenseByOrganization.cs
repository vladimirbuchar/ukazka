namespace Model.Functions.License
{

    public class GetLicenseByOrganization : SqlFunction
    {
        public int MaximumBranch { get; set; }
        public int MaximumCourse { get; set; }
        public bool CreatePrivateCourse { get; set; }
        public int MaximumStudents { get; set; }
        public int MaximumLectors { get; set; }
        public double MounthPrice { get; set; }
        public double OneYearSale { get; set; }
        public double OneYearPrice { get; set; }
        public bool Support { get; set; }
        public bool SendCourseInquiry { get; set; }
    }
}
