using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_TestQuestionAnswer")]
    public class TestQuestionAnswer : TableModel
    {
        [Column("Answer")]
        public virtual string Answer { get; set; }
        [Column("IsTrueAnswer")]
        public virtual bool IsTrueAnswer { get; set; }
    }
}
