using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.CodeBook
{
    public struct CourseTypeValues
    {
        public const string ONLINE = "ONLINE";
        public const string ATTENDANCE = "ATTENDANCE";
        public const string COMBINED = "COMBINED";
    }
    [Table("Cb_CourseType")]
    public class CourseType : CodeBook
    {
    }
}
