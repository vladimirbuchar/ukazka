using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.CodeBook
{
    public struct LicenseValues
    {
        public const string FREE = "FREE";
        public const string STANDARD = "STANDARD";
        public const string PROFESIONAL = "PROFESIONAL";
        public const string ENTERPRISE = "ENTERPRISE";

    }
    [Table("Cb_License")]
    public class License : CodeBook
    {
        [Column("MaximumBranch")]
        public virtual int MaximumBranch { get; set; }
        [Column("MaximumCourse")]
        public virtual int MaximumCourse { get; set; }
        [Column("CreatePrivateCourse")]
        public virtual bool CreatePrivateCourse { get; set; }
        [Column("MaximumUser")]
        public virtual int MaximumUser { get; set; }
        [Column("MounthPrice")]
        public virtual double MounthPrice { get; set; }
        [Column("OneYearSale")]
        public virtual double OneYearSale { get; set; }
        [Column("SendCourseInquiry")]
        public virtual bool SendCourseInquiry { get; set; }
    }
}
