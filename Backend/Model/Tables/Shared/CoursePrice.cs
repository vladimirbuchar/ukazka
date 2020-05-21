using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Shared
{
    [Table("Shared_CoursePrice")]
    public class CoursePrice : TableModel
    {
        [Column("Price")]
        public virtual double Price { get; set; }
        [Column("Sale")]
        public virtual int Sale { get; set; }
    }
}
