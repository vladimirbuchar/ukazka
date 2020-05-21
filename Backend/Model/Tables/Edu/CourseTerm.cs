using Model.Tables.CodeBook;
using Model.Tables.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_CourseTerm")]
    public class CourseTerm : TableModel
    {
        [Column("ActiveFrom")]
        public virtual DateTime? ActiveFrom { get; set; }

        [Column("ActiveTo")]
        public virtual DateTime? ActiveTo { get; set; }

        [Column("RegistrationFrom")]
        public virtual DateTime? RegistrationFrom { get; set; }

        [Column("RegistrationTo")]
        public virtual DateTime? RegistrationTo { get; set; }

        [Column("Monday")]
        public virtual bool Monday { get; set; }

        [Column("Tuesday")]
        public virtual bool Tuesday { get; set; }

        [Column("Wednesday")]
        public virtual bool Wednesday { get; set; }

        [Column("Thursday")]
        public virtual bool Thursday { get; set; }

        [Column("Friday")]
        public virtual bool Friday { get; set; }

        [Column("Saturday")]
        public virtual bool Saturday { get; set; }

        [Column("Sunday")]
        public virtual bool Sunday { get; set; }

        public virtual BasicInformation BasicInformation { get; set; }
        public virtual StudentCount StudentCount { get; set; }
        public virtual CoursePrice CoursePrice { get; set; }
        public virtual TimeTable TimeFrom { get; set; }
        public virtual TimeTable TimeTo { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
    }
}
