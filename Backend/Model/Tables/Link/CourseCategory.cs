using Model.Tables.Edu;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Link
{
    [Table("Link_CourseCategory")]
    public class CourseCategory : TableModel
    {
        public virtual Category Category { get; set; }
        public virtual Course Course { get; set; }
    }
}
