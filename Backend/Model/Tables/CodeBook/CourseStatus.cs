using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.CodeBook
{
    public struct CourseStatusValues
    {
        public const string NEW = "NEW";
        public const string IN_PREPARATION = "IN_PREPARATION";
        public const string OPEN = "OPEN";
        public const string ONGOING = "ONGOING";
        public const string CLOSED = "CLOSED";
    }
    [Table("Cb_CourseStatus")]
    public class CourseStatus : CodeBook
    {
    }
}
