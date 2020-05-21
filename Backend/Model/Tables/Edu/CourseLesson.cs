using Model.Tables.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_CourseLesson")]
    public class CourseLesson : TableModel
    {
        public virtual BasicInformation BasicInformation { get; set; }

        public virtual IEnumerable<CourseItem> CourseItem { get; set; }
    }
}
