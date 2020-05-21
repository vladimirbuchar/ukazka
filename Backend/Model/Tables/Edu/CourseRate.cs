using Model.Tables.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_CourseRate")]
    public class CourseRate : TableModel
    {
        [Column("Rate")]
        public virtual int Rate { get; set; }

        [Column("RateDate")]
        public virtual DateTime RateDate { get; set; }

        [Column("IsActive")]
        public virtual bool IsActive { get; set; } = true;

        public virtual CourseRate OldRate { get; set; }
        public virtual User User { get; set; }
        public virtual BasicInformation BasicInformation { get; set; }
    }
}
