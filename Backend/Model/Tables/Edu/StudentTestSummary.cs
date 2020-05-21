using Model.Tables.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_StudentTestSummary")]
    public class StudentTestSummary : TableModel
    {
        [Column("StartTime")]
        public virtual DateTime? StartTime { get; set; }

        [Column("Score")]
        public virtual double Score { get; set; }

        [Column("Finish")]
        public virtual DateTime? Finish { get; set; }

        [Column("TestCompleted")]
        public virtual bool TestCompleted { get; set; }

        public virtual CourseTest CourseTest { get; set; }
        public virtual User User { get; set; }
        public virtual BasicInformation BasicInformation { get; set; }

    }
}
