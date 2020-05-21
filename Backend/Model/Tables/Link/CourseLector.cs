using Model.Tables.Edu;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Link
{
    [Table("Link_CourseLector")]
    public class CourseLector : TableModel
    {
        public virtual UserInOrganization UserInOrganization { get; set; }
        public virtual CourseTerm CourseTerm { get; set; }
    }
}
