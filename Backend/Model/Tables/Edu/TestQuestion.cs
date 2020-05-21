using Model.Tables.CodeBook;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_TestQuestion")]
    public class TestQuestion : TableModel
    {
        [Column("Question")]
        public virtual string Question { get; set; }
        public virtual AnswerMode AnswerMode { get; set; }
        public virtual IEnumerable<TestQuestionAnswer> TestQuestionAnswer { get; set; }
    }
}
