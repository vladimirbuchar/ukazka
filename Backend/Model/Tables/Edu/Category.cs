using Model.Tables.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_Category")]
    public class Category : TableModel
    {
        public virtual BasicInformation BasicInformation { get; set; }
        public virtual IEnumerable<Category> ChildCategory { get; set; }
        public virtual IEnumerable<Course> Course { get; set; }
    }
}