using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Shared
{
    [Table("Shared_StudentCount")]
    public class StudentCount : TableModel
    {
        [Column("MinimumStudent")]
        public virtual int MinimumStudent { get; set; }
        [Column("MaximumStudent")]
        public virtual int MaximumStudent { get; set; }
    }
}
