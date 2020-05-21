using Model.Tables.Edu;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Link
{
    [Table("Link_CourseStudent")]
    public class CourseStudent : TableModel
    {
        public virtual UserInOrganization User { get; set; }
        public virtual CourseTerm CourseTerm { get; set; }
    }
}
