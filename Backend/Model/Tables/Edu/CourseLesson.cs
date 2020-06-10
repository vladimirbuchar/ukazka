using Model.Tables.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_CourseLesson")]
    public class CourseLesson : TableModel
    {
        public virtual BasicInformation BasicInformation { get; set; }
        public virtual int Position { get; set; } = 0;

        public virtual IEnumerable<CourseLessonItem> CourseItem { get; set; }
    }
}
