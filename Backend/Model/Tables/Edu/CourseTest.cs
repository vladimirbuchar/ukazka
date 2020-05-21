using Model.Tables.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_CourseTest")]
    public class CourseTest : TableModel
    {
        [Column("IsRandomGenerateQuestion")]
        public virtual bool IsRandomGenerateQuestion { get; set; }

        [Column("QuestionCountInTest")]
        public virtual int QuestionCountInTest { get; set; }

        [Column("TimeLimit")]
        public virtual int TimeLimit { get; set; }

        [Column("DesiredSuccess")]
        public virtual int DesiredSuccess { get; set; }

        public virtual BasicInformation BasicInformation { get; set; }
    }
}
