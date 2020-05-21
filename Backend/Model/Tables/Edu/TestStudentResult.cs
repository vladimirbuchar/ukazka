using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_TestStudentResult")]
    public class TestStudentResult : TableModel
    {
        [Column("Result")]
        public virtual double Result { get; set; }
        public virtual User User { get; set; }
        public virtual CourseTest CourseTest { get; set; }
    }
}
